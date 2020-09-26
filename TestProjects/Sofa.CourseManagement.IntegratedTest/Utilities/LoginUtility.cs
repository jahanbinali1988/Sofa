using Newtonsoft.Json.Linq;
using Polly;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.IntegratedTest.Utilities
{
    public static class LoginUtility
    {
        public static HttpClient GetAuthenticatedHttpClient(string userName, string password, HttpClient httpClient)
        {
            var token = GetAccessToken(userName, password).Result;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return httpClient;
        }

        private static async Task<string> GetAccessToken(string userName, string password)
        {
            var data = $"grant_type=password&client_id=AndroidClient&client_secret=secret&scope=api+offline_access&username={userName}&password={password}";
            var stringContent = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");

            var httpClient = new HttpClient();
            var response = await Policy
                .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode).Or<HttpRequestException>()
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(5), (result, timeSpan, retryCount, context) =>
                {

                }).ExecuteAsync(() => httpClient.PostAsync("http://localhost:5000/connect/token", stringContent));

            response.EnsureSuccessStatusCode();

            var responseJson = response.Content.ReadAsStringAsync().Result;
            var jObject = JObject.Parse(responseJson);
            var token = jObject.GetValue("access_token").ToString();

            return token;
        }
    }
}
