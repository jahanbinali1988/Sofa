using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System;
using System.Net.Http;
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
            var url = ConstantsUrl.GetInstituteByIdApiUrl + DefaultData.defaultInstituteId;
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
                Code = Guid.NewGuid().ToString(),
                Address = new AddressDto()
                {
                    City = Guid.NewGuid().ToString(),
                    ZipCode = Guid.NewGuid().ToString(),
                    Country = Guid.NewGuid().ToString(),
                    State = Guid.NewGuid().ToString(),
                    Street = Guid.NewGuid().ToString()
                }
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddInstituteResponse>(ConstantsUrl.AddInstituteApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
