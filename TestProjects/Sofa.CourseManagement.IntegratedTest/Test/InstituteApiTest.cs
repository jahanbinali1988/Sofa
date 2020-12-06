using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
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
            var url = ConstantsUrl.GetInstituteByIdApiUrl + DefaultData.InstituteId;
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
                },
                WebsiteUrl = "www." + Guid.NewGuid().ToString() + ".com"
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddInstituteResponse>(ConstantsUrl.AddInstituteApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll()
        {
            var request = new GetAllInstituteRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10
            };

            var result = sysAdminHttpClient.CallPostService<GetAllInstituteResponse>(ConstantsUrl.GetAllInstituteApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete()
        {
            var addRequest = new AddInstituteRequest()
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
                },
                WebsiteUrl = "www." + Guid.NewGuid().ToString() + ".com"
            };
            var addResult = sysAdminHttpClient.CallPostService<AddInstituteResponse>(ConstantsUrl.AddInstituteApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new DeleteInstituteRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<DeleteInstituteResponse>(ConstantsUrl.DeleteInstituteApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Update
        [Fact]
        public void Update()
        {
            var addRequest = new AddInstituteRequest()
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
                },
                WebsiteUrl = "www." + Guid.NewGuid().ToString() + ".com"
            };
            var addResult = sysAdminHttpClient.CallPostService<AddInstituteResponse>(ConstantsUrl.AddInstituteApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new UpdateInstituteRequest
            {
                Id = addResult.NewRecordedId,
                Title = Guid.NewGuid().ToString()
            };
            var result = sysAdminHttpClient.CallPostService<UpdateInstituteResponse>(ConstantsUrl.UpdateInstituteApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region ChangeActiveStatus
        [Fact]
        public void ChangeActiveStatus()
        {
            var addRequest = new AddInstituteRequest
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
                },
                WebsiteUrl = "www." + Guid.NewGuid().ToString() + ".com"
            };
            var addResult = sysAdminHttpClient.CallPostService<AddInstituteResponse>(ConstantsUrl.AddInstituteApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new ChangeActiveStatusCourseRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<ChangeActiveStatusInstituteResponse>(ConstantsUrl.ChangeActiveStatusInstituteApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Search
        [Fact]
        public void Search()
        {
            var request = new SearchInstituteRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                Caption = ""
            };

            var result = sysAdminHttpClient.CallPostService<SearchInstituteResponse>(ConstantsUrl.SearchInstituteApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
