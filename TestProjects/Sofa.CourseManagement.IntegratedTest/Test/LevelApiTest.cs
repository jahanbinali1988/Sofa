using Sofa.CourseManagement.IntegratedTest.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class LevelApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        public LevelApiTest(TestContextFixture contextFixture)
            : base(contextFixture)
        {
             sysAdminHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.SysAdminUsername, DefaultData.SysAdminPassword);
             teacherHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.TeacherUsername, DefaultData.TeacherPassword);
        }

        #region Add
        [Fact]
        public void Add()
        {
            var request = new AddLevelRequest
            {
                Title = Guid.NewGuid().ToString()
            };

            var result = sysAdminHttpClient.CallPostService<AddLevelResponse>(ConstantsUrl.LevelAddApiUrl, request);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Add_UserDontLogin_UnauthorizedError()
        {
            var request = new AddLevelRequest
            {
                Title = Guid.NewGuid().ToString()
            };

            var httpClient = testContext.GetHttpClient();
            var response = httpClient.PostAsJsonAsync(ConstantsUrl.LevelAddApiUrl, request).Result;
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }
        #endregion
    }
}
