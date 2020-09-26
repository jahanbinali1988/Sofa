using Sofa.CourseManagement.IntegratedTest.Utilities;
using System;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class UserApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        public UserApiTest(TestContextFixture contextFixture)
            : base(contextFixture)
        {
            sysAdminHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.SysAdminUsername, DefaultData.SysAdminPassword);
            teacherHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.TeacherUsername, DefaultData.TeacherPassword);
        }

        #region Add
        [Fact]
        public void Add()
        {
            var request = new AddUserRequest
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                FirstName = Guid.NewGuid().ToString(),
                IsActive = true,
                LastName = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                PhoneNumber = Guid.NewGuid().ToString(),

                UserName = Guid.NewGuid().ToString(),
                Role = 2
            };

            var result = sysAdminHttpClient.CallPostService<AddUserResponse>(ConstantsUrl.AddUserApiUrl, request);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Add_UserDontLogin_UnauthorizedError()
        {
            var request = new AddUserRequest
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                FirstName = Guid.NewGuid().ToString(),
                IsActive = true,
                LastName = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                PhoneNumber = Guid.NewGuid().ToString(),
                UserName = Guid.NewGuid().ToString(),
                Role = 2
            };

            var httpClient = testContext.GetHttpClient();
            var response = httpClient.PostAsJsonAsync(ConstantsUrl.AddUserApiUrl, request).Result;
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }
        #endregion
    }
}
