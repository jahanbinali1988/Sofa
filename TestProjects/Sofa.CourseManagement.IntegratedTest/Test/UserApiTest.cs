using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
using System;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class UserApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public UserApiTest(TestContextFixture contextFixture)
            : base(contextFixture)
        {
            sysAdminHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.SysAdminUsername, DefaultData.SysAdminPassword);
            teacherHttpClient = testContext.GetAuthenticatedHttpClient(DefaultData.TeacherUsername, DefaultData.TeacherPassword);
            unknownHttpClient = testContext.GetHttpClient();
        }

        #region Add
        [Fact]
        public void Add()
        {
            var request = new AddUserRequest
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                FirstName = Guid.NewGuid().ToString(),
                IsActive = true,
                LastName = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                PhoneNumber = Guid.NewGuid().ToString(),
                UserName = Guid.NewGuid().ToString(),
                Role = 2
            };

            var result = sysAdminHttpClient.CallPostService<AddUserResponse>(ConstantsUrl.AddUserApiUrl, request);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Add_UserDontLogin_UnauthorizedError()
        {
            var request = new AddUserRequest
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                FirstName = Guid.NewGuid().ToString(),
                IsActive = true,
                LastName = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                PhoneNumber = Guid.NewGuid().ToString(),
                UserName = Guid.NewGuid().ToString(),
                Role = 2
            };

            var httpClient = testContext.GetHttpClient();
            var response = httpClient.PostAsJsonAsync(ConstantsUrl.AddUserApiUrl, request).Result;
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }
        #endregion

        #region GetById
        [Fact]
        public void GetById()
        {
            var result = sysAdminHttpClient.CallGetService<GetUserByIdResponse>(ConstantsUrl.GetUserApiUrl + DefaultData.StudentId);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll()
        {
            var request = new GetAllUserRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10
            };

            var result = sysAdminHttpClient.CallPostService<GetAllUserResponse>(ConstantsUrl.GetAllUserApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete()
        {
            var addRequest = new AddUserRequest
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                FirstName = Guid.NewGuid().ToString(),
                IsActive = true,
                LastName = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                PhoneNumber = Guid.NewGuid().ToString(),
                UserName = Guid.NewGuid().ToString(),
                Role = 2
            };
            var addResult = sysAdminHttpClient.CallPostService<AddUserResponse>(ConstantsUrl.AddUserApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new DeleteUserRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<DeleteUserResponse>(ConstantsUrl.DeleteUserApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Update
        [Fact]
        public void Update()
        {
            var addRequest = new AddUserRequest
            {
                Email = Guid.NewGuid().ToString() + "@gmail.com",
                FirstName = Guid.NewGuid().ToString(),
                IsActive = true,
                LastName = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                PhoneNumber = Guid.NewGuid().ToString(),
                UserName = Guid.NewGuid().ToString(),
                Role = 2
            };
            var addResult = sysAdminHttpClient.CallPostService<AddUserResponse>(ConstantsUrl.AddUserApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new UpdateUserRequest
            {
                Id = addResult.NewRecordedId,
                Email = Guid.NewGuid().ToString() + "@gmail.com",
            };
            var result = sysAdminHttpClient.CallPostService<UpdateUserResponse>(ConstantsUrl.UpdateUserApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
