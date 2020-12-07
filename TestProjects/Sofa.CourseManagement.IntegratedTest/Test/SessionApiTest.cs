using Sofa.CourseManagement.IntegratedTest.Messages;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;
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
            var url = ConstantsUrl.GetSessionByIdApiUrl + DefaultData.SessionId;
            var result = unknownHttpClient.CallGetService<Messages.GetSessionByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Add
        [Fact]
        public void Add()
        {
            var addLessonPlanRequest = new ApplicationService.AddLessonPlanRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Level = (short)LevelEnum.Advanced
            };

            var addLessonPlanResult = sysAdminHttpClient.CallPostService<Messages.AddLessonPlanResponse>(ConstantsUrl.AddLessonPlanApiUrl, addLessonPlanRequest);
            Assert.True(addLessonPlanResult.IsSuccess);

            var request = new ApplicationService.AddSessionRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                LessonPlanId = addLessonPlanResult.NewRecordedId,
                TermId = DefaultData.TermId
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddSessionResponse>(ConstantsUrl.AddSessionApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll()
        {
            var request = new ApplicationService.GetAllTermRequest
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
            var addLessonPlanRequest = new ApplicationService.AddLessonPlanRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Level = (short)LevelEnum.Advanced
            };

            var addLessonPlanResult = sysAdminHttpClient.CallPostService<Messages.AddLessonPlanResponse>(ConstantsUrl.AddLessonPlanApiUrl, addLessonPlanRequest);
            Assert.True(addLessonPlanResult.IsSuccess);

            var addRequest = new ApplicationService.AddSessionRequest
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                LessonPlanId = addLessonPlanResult.NewRecordedId,
                TermId = DefaultData.TermId
            };
            var addResult = sysAdminHttpClient.CallPostService<AddSessionResponse>(ConstantsUrl.AddSessionApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new ApplicationService.DeleteSessionRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<DeleteSessionResponse>(ConstantsUrl.DeleteSessionApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Update
        [Fact]
        public void Update()
        {
            var addLessonPlanRequest = new ApplicationService.AddLessonPlanRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Level = (short)LevelEnum.Advanced
            };

            var addLessonPlanResult = sysAdminHttpClient.CallPostService<Messages.AddLessonPlanResponse>(ConstantsUrl.AddLessonPlanApiUrl, addLessonPlanRequest);
            Assert.True(addLessonPlanResult.IsSuccess);

            var addRequest = new ApplicationService.AddSessionRequest
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                LessonPlanId = addLessonPlanResult.NewRecordedId,
                TermId = DefaultData.TermId
            };
            var addResult = sysAdminHttpClient.CallPostService<AddSessionResponse>(ConstantsUrl.AddSessionApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new ApplicationService.UpdateSessionRequest
            {
                Id = addResult.NewRecordedId,
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                LessonPlanId = addLessonPlanResult.NewRecordedId,
                TermId = DefaultData.TermId
            };
            var result = sysAdminHttpClient.CallPostService<UpdateSessionResponse>(ConstantsUrl.UpdateSessionApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region ChangeActiveStatus
        [Fact]
        public void ChangeActiveStatus()
        {
            var addLessonPlanRequest = new ApplicationService.AddLessonPlanRequest()
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Level = (short)LevelEnum.Advanced
            };

            var addLessonPlanResult = sysAdminHttpClient.CallPostService<Messages.AddLessonPlanResponse>(ConstantsUrl.AddLessonPlanApiUrl, addLessonPlanRequest);
            Assert.True(addLessonPlanResult.IsSuccess);

            var addRequest = new ApplicationService.AddSessionRequest
            {
                IsActive = false,
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                LessonPlanId = addLessonPlanResult.NewRecordedId,
                TermId = DefaultData.TermId
            };
            var addResult = sysAdminHttpClient.CallPostService<AddSessionResponse>(ConstantsUrl.AddSessionApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new ApplicationService.ChangeActiveStatusSessionRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<ChangeActiveStatusSessionResponse>(ConstantsUrl.ChangeActiveStatusSessionApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Search
        [Fact]
        public void Search()
        {
            var request = new ApplicationService.SearchSessionRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                Caption = ""
            };

            var result = sysAdminHttpClient.CallPostService<SearchSessionResponse>(ConstantsUrl.SearchSessionApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
