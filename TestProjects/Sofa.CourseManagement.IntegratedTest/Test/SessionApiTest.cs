using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
using System;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class SessionApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public SessionApiTest(TestContextFixture contextFixture)
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
            var url = ConstantsUrl.GetSessionByIdApiUrl + "";
            var result = unknownHttpClient.CallGetService<Messages.GetSessionByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Add
        [Fact]
        public void Add()
        {
            var request = new AddSessionRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddSessionResponse>(ConstantsUrl.AddSessionApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll()
        {
            var request = new GetAllTermRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10
            };

            var result = sysAdminHttpClient.CallPostService<GetAllTermResponse>(ConstantsUrl.GetAllTermApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete()
        {
            var addRequest = new AddTermRequest
            {
                Title = "Sample",
                CourseId = DefaultData.CourseId,
                IsActive = false
            };
            var addResult = sysAdminHttpClient.CallPostService<AddTermResponse>(ConstantsUrl.AddTermApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new DeleteTermRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<DeleteTermResponse>(ConstantsUrl.DeleteTermApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Update
        [Fact]
        public void Update()
        {
            var addRequest = new AddTermRequest
            {
                Title = "Sample",
                CourseId = DefaultData.CourseId,
                IsActive = false
            };
            var addResult = sysAdminHttpClient.CallPostService<AddTermResponse>(ConstantsUrl.AddTermApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new UpdateTermRequest
            {
                Id = addResult.NewRecordedId,
                Title = Guid.NewGuid().ToString()
            };
            var result = sysAdminHttpClient.CallPostService<UpdateUserResponse>(ConstantsUrl.UpdateUserApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
