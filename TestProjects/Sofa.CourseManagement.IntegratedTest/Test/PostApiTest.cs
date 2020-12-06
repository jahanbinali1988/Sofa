using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;
using System;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class PostApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public PostApiTest(TestContextFixture contextFixture)
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
            var url = ConstantsUrl.GetPostByIdApiUrl + DefaultData.PostId;
            var result = unknownHttpClient.CallGetService<Messages.GetPostByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region AddPost
        [Fact]
        public void Add()
        {
            var request = new AddPostRequest
            {
                Title = Guid.NewGuid().ToString(),
                LessonPlanId = DefaultData.LessonPlanId,
                Order = 1,
                ContentType = (short)ContentTypeEnum.Text,
                Content = Guid.NewGuid().ToString(),
                IsActive = false,
                Description = Guid.NewGuid().ToString()
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddPostResponse>(ConstantsUrl.AddPostApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll()
        {
            var request = new GetAllPostRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                LessonPlanId = DefaultData.LessonPlanId
            };

            var result = sysAdminHttpClient.CallPostService<GetAllPostResponse>(ConstantsUrl.GetAllPostApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete()
        {
            var addRequest = new AddPostRequest
            {
                Title = Guid.NewGuid().ToString(),
                LessonPlanId = DefaultData.LessonPlanId,
                Order = 1,
                ContentType = (short)ContentTypeEnum.Text,
                Content = Guid.NewGuid().ToString(),
                IsActive = false,
                Description = Guid.NewGuid().ToString()
            };
            var addResult = sysAdminHttpClient.CallPostService<AddPostResponse>(ConstantsUrl.AddPostApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new DeletePostRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<DeletePostResponse>(ConstantsUrl.DeletePostApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Update
        [Fact]
        public void Update()
        {
            var addRequest = new AddPostRequest
            {
                Title = Guid.NewGuid().ToString(),
                LessonPlanId = DefaultData.LessonPlanId,
                Order = 1,
                ContentType = (short)ContentTypeEnum.Text,
                Content = Guid.NewGuid().ToString(),
                IsActive = false,
                Description = Guid.NewGuid().ToString()
            };
            var addResult = sysAdminHttpClient.CallPostService<AddPostResponse>(ConstantsUrl.AddPostApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new UpdatePostRequest
            {
                Id = addResult.NewRecordedId,
                Title = Guid.NewGuid().ToString()
            };
            var result = sysAdminHttpClient.CallPostService<UpdatePostResponse>(ConstantsUrl.UpdatePostApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region ChangeActiveStatus
        [Fact]
        public void ChangeActiveStatus()
        {
            var addRequest = new AddPostRequest
            {
                Title = Guid.NewGuid().ToString(),
                LessonPlanId = DefaultData.LessonPlanId,
                Order = 1,
                ContentType = (short)ContentTypeEnum.Text,
                Content = Guid.NewGuid().ToString(),
                IsActive = false,
                Description = Guid.NewGuid().ToString()
            };
            var addResult = sysAdminHttpClient.CallPostService<AddPostResponse>(ConstantsUrl.AddPostApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new DeletePostRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<ChangeActiveStatusPostResponse>(ConstantsUrl.ChangeActiveStatusPostApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Search
        [Fact]
        public void Search()
        {
            var request = new SearchPostRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                Caption = ""
            };

            var result = sysAdminHttpClient.CallPostService<SearchPostResponse>(ConstantsUrl.SearchPostApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
