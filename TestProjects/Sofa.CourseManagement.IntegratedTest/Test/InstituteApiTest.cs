using Sofa.CourseManagement.IntegratedTest.Messages;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class InstituteApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        public InstituteApiTest(TestContextFixture contextFixture)
            : base(contextFixture)
        {
            sysAdminHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.SysAdminUsername, DefaultData.SysAdminPassword);
            teacherHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.TeacherUsername, DefaultData.TeacherPassword);
        }

        #region GetById
        [Fact]
        public void GetById()
        {
            var request = new GetInstituteByIdRequest()
            {
                Id = Guid.NewGuid()
            };

            var url = ConstantsUrl.GetInstituteByIdApiUrl + request;
            var result = sysAdminHttpClient.CallGetService<GetInstituteByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
