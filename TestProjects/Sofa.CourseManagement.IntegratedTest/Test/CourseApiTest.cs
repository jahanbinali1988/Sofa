using Sofa.CourseManagement.IntegratedTest.Messages;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;
using System;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class CourseApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public CourseApiTest(TestContextFixture contextFixture)
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
            var url = ConstantsUrl.GetCourseByIdApiUrl + DefaultData.CourseId;
            var result = unknownHttpClient.CallGetService<Messages.GetCourseByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region AddCourse
        [Fact]
        public void Add()
        {
            var request = new Sofa.CourseManagement.ApplicationService.AddCourseRequest()
            {
                FieldId = DefaultData.FieldId,
                AgeRange = AgeRangeEnum.Adults,
                IsActive = false,
                Title = Guid.NewGuid().ToString()
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddCourseResponse>(ConstantsUrl.AddCourseApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll()
        {
            var request = new Sofa.CourseManagement.ApplicationService.GetAllCourseRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                FieldId = DefaultData.FieldId
            };

            var result = sysAdminHttpClient.CallPostService<GetAllCourseResponse>(ConstantsUrl.GetAllCourseApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete()
        {
            var addRequest = new Sofa.CourseManagement.ApplicationService.AddCourseRequest
            {
                Title = Guid.NewGuid().ToString(),
                IsActive = false,
                AgeRange = AgeRangeEnum.Adults,
                FieldId = DefaultData.FieldId
            };
            var addResult = sysAdminHttpClient.CallPostService<AddCourseResponse>(ConstantsUrl.AddCourseApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new Sofa.CourseManagement.ApplicationService.DeleteCourseRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<DeleteCourseResponse>(ConstantsUrl.DeleteCourseApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Update
        [Fact]
        public void Update()
        {
            var addRequest = new Sofa.CourseManagement.ApplicationService.AddCourseRequest
            {
                Title = Guid.NewGuid().ToString(),
                IsActive = false,
                AgeRange = AgeRangeEnum.Adults,
                FieldId = DefaultData.FieldId
            };
            var addResult = sysAdminHttpClient.CallPostService<AddCourseResponse>(ConstantsUrl.AddCourseApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new Sofa.CourseManagement.ApplicationService.UpdateCourseRequest
            {
                Id = addResult.NewRecordedId,
                Title = Guid.NewGuid().ToString(),
                IsActive = false,
                AgeRange = AgeRangeEnum.Adults,
                FieldId = DefaultData.FieldId
            };
            var result = sysAdminHttpClient.CallPostService<UpdateCourseResponse>(ConstantsUrl.UpdateCourseApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region ChangeActiveStatus
        [Fact]
        public void ChangeActiveStatus()
        {
            var addRequest = new Sofa.CourseManagement.ApplicationService.AddCourseRequest
            {
                Title = Guid.NewGuid().ToString(),
                IsActive = false,
                AgeRange = AgeRangeEnum.Adults,
                FieldId = DefaultData.FieldId
            };
            var addResult = sysAdminHttpClient.CallPostService<AddCourseResponse>(ConstantsUrl.AddCourseApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new Sofa.CourseManagement.ApplicationService.ChangeActiveStatusCourseRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<ChangeActiveStatusCourseResponse>(ConstantsUrl.ChangeActiveStatusCourseApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Search
        [Fact]
        public void Search()
        {
            var request = new Sofa.CourseManagement.ApplicationService.SearchCourseRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                Caption = ""
            };

            var result = sysAdminHttpClient.CallPostService<SearchCourseResponse>(ConstantsUrl.SearchCourseApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
