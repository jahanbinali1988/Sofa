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
    public class InstituteApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public InstituteApiTest(TestContextFixture contextFixture)
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
            var url = ConstantsUrl.GetInstituteByIdApiUrl + "EAB09285-AE8B-4396-B041-32A3E60D5512";
            var result = unknownHttpClient.CallGetService<Messages.GetInstituteByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region AddInstitute
        [Fact]
        public void Add()
        {
            var request = new AddInstituteRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Addresses = new List<AddressDto>() { 
                    new AddressDto(){
                        City = Guid.NewGuid().ToString(),
                        ZipCode = Guid.NewGuid().ToString(),
                        Country = Guid.NewGuid().ToString(),
                        State = Guid.NewGuid().ToString(),
                        Street = Guid.NewGuid().ToString()
                    } 
                }
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddInstituteResponse>(ConstantsUrl.AddInstituteApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
