using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;
using System;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class LessonPlanApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public LessonPlanApiTest(TestContextFixture contextFixture)
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
            var url = ConstantsUrl.GetLessonPlanByIdApiUrl + DefaultData.LessonPlanId;
            var result = unknownHttpClient.CallGetService<Messages.GetLessonPlanByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region AddLessonPlan
        [Fact]
        public void Add()
        {
            var request = new AddLessonPlanRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Level = (short)LevelEnum.Advanced
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddLessonPlanResponse>(ConstantsUrl.AddLessonPlanApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll()
        {
            var request = new GetAllLessonPlanRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                SessionId = DefaultData.SessionId
            };

            var result = sysAdminHttpClient.CallPostService<GetAllLessonPlanResponse>(ConstantsUrl.GetAllLessonPlanApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete()
        {
            var addRequest = new AddLessonPlanRequest
            {
                Title = Guid.NewGuid().ToString(),
                IsActive = false,
                Level = (short)LevelEnum.Advanced
            };
            var addResult = sysAdminHttpClient.CallPostService<AddLessonPlanResponse>(ConstantsUrl.AddLessonPlanApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new DeleteLessonPlanRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<DeleteLessonPlanResponse>(ConstantsUrl.DeleteLessonPlanApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Update
        [Fact]
        public void Update()
        {
            var addRequest = new AddLessonPlanRequest
            {
                Title = Guid.NewGuid().ToString(),
                IsActive = false,
                Level = (short)LevelEnum.Advanced
            };
            var addResult = sysAdminHttpClient.CallPostService<AddLessonPlanResponse>(ConstantsUrl.AddLessonPlanApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new UpdateLessonPlanRequest
            {
                Id = addResult.NewRecordedId,
                Level = (short)LevelEnum.Begginer
            };
            var result = sysAdminHttpClient.CallPostService<UpdateLessonPlanResponse>(ConstantsUrl.UpdateLessonPlanApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region ChangeActiveStatus
        [Fact]
        public void ChangeActiveStatus()
        {
            var addRequest = new AddLessonPlanRequest
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Level = (short)LevelEnum.Advanced
            };
            var addResult = sysAdminHttpClient.CallPostService<AddLessonPlanResponse>(ConstantsUrl.AddLessonPlanApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new DeleteLessonPlanRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<ChangeActiveStatusLessonPlanResponse>(ConstantsUrl.ChangeActiveStatusLessonPlanApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Search
        [Fact]
        public void Search()
        {
            var request = new SearchLessonPlanRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                Caption = ""
            };

            var result = sysAdminHttpClient.CallPostService<SearchLessonPlanResponse>(ConstantsUrl.SearchLessonPlanApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
