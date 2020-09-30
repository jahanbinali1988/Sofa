using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
using System;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class FieldApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public FieldApiTest(TestContextFixture contextFixture)
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
            var url = ConstantsUrl.GetFieldByIdApiUrl + DefaultData.FieldId;
            var result = unknownHttpClient.CallGetService<Messages.GetFieldByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region AddField
        [Fact]
        public void Add()
        {
            var request = new AddFieldRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                InstituteId = DefaultData.InstituteId
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddFieldResponse>(ConstantsUrl.AddFieldApiUrl, request);
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
                PageSize = 10,
                CourseId = DefaultData.CourseId
            };

            var result = sysAdminHttpClient.CallPostService<GetAllFieldResponse>(ConstantsUrl.GetAllFieldApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete()
        {
            var addRequest = new AddFieldRequest
            {
                Title = Guid.NewGuid().ToString(),
                InstituteId = DefaultData.InstituteId,
                IsActive = false
            };
            var addResult = sysAdminHttpClient.CallPostService<AddFieldResponse>(ConstantsUrl.AddFieldApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new DeleteFieldRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<DeleteFieldResponse>(ConstantsUrl.DeleteFieldApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Update
        [Fact]
        public void Update()
        {
            var addRequest = new AddFieldRequest
            {
                Title = Guid.NewGuid().ToString(),
                InstituteId = DefaultData.InstituteId,
                IsActive = false
            };
            var addResult = sysAdminHttpClient.CallPostService<AddFieldResponse>(ConstantsUrl.AddFieldApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new UpdateFieldRequest
            {
                Id = addResult.NewRecordedId,
                Title = Guid.NewGuid().ToString()
            };
            var result = sysAdminHttpClient.CallPostService<UpdateFieldResponse>(ConstantsUrl.UpdateFieldApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
