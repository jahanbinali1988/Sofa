using Microsoft.VisualBasic;
using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Messages;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.CourseManagement.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class TermApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public TermApiTest(TestContextFixture contextFixture)
            : base(contextFixture)
        {
            sysAdminHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.SysAdminUsername, DefaultData.SysAdminPassword);
            teacherHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.TeacherUsername, DefaultData.TeacherPassword);
            unknownHttpClient = testContext.GetHttpClient();
        }

        #region GetById
        [Fact]
        public void GetById()
        {
            var url = ConstantsUrl.GetTermByIdApiUrl + "";
            var result = unknownHttpClient.CallGetService<Messages.GetTermByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region AddTerm
        [Fact]
        public void Add()
        {
            var request = new AddTermRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddTermResponse>(ConstantsUrl.AddTermApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
