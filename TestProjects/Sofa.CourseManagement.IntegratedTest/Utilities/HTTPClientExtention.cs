using System.Net.Http;

namespace Sofa.CourseManagement.IntegratedTest.Utilities
{
    public static class HTTPClientExtention
    {
        public static T CallPostService<T>(this HttpClient httpClient, string url, object request) where T : class
        {
            var response = httpClient.PostAsJsonAsync(url, request).Result;
            var error = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsAsync<T>().Result;
            return result;
        }

        public static T CallGetService<T>(this HttpClient httpClient, string url)
        {
            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsAsync<T>().Result;
            return result;
        }
    }
}
