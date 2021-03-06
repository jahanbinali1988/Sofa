﻿using Sofa.CourseManagement.IntegratedTest.Messages;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.SharedKernel;
using System;
using System.Net.Http;
using Xunit;

namespace Sofa.CourseManagement.IntegratedTest.Test
{
    public class TermApiTest : SofaTestClassBase
    {
        HttpClient sysAdminHttpClient;
        HttpClient teacherHttpClient;
        HttpClient unknownHttpClient;
        public TermApiTest(TestContextFixture contextFixture)
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
            var url = ConstantsUrl.GetTermByIdApiUrl + DefaultData.TermId;
            var result = unknownHttpClient.CallGetService<Messages.GetTermByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region AddTerm
        [Fact]
        public void Add()
        {
            var request = new ApplicationService.AddTermRequest()
            {
                Description = Guid.NewGuid().ToString(),
                CourseId = DefaultData.CourseId,
                IsActive = false,
                Title = Guid.NewGuid().ToString()
            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddTermResponse>(ConstantsUrl.AddTermApiUrl, request);
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
            var addRequest = new ApplicationService.AddTermRequest
            {
                Description = Guid.NewGuid().ToString(),
                CourseId = DefaultData.CourseId,
                IsActive = false,
                Title = Guid.NewGuid().ToString()
            };
            var addResult = sysAdminHttpClient.CallPostService<AddTermResponse>(ConstantsUrl.AddTermApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new ApplicationService.DeleteTermRequest
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
            var addRequest = new ApplicationService.AddTermRequest
            {
                Description = Guid.NewGuid().ToString(),
                CourseId = DefaultData.CourseId,
                IsActive = false,
                Title = Guid.NewGuid().ToString()
            };
            var addResult = sysAdminHttpClient.CallPostService<AddTermResponse>(ConstantsUrl.AddTermApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new ApplicationService.UpdateTermRequest
            {
                Id = addResult.NewRecordedId,
                Title = Guid.NewGuid().ToString(),
                CourseId = DefaultData.CourseId,
                IsActive = false
            };
            var result = sysAdminHttpClient.CallPostService<UpdateUserResponse>(ConstantsUrl.UpdateTermApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region ChangeActiveStatus
        [Fact]
        public void ChangeActiveStatus()
        {
            var addRequest = new ApplicationService.AddTermRequest()
            {
                Description = Guid.NewGuid().ToString(),
                CourseId = DefaultData.CourseId,
                IsActive = false,
                Title = Guid.NewGuid().ToString()
            };
            var addResult = sysAdminHttpClient.CallPostService<AddTermResponse>(ConstantsUrl.AddTermApiUrl, addRequest);
            Assert.True(addResult.IsSuccess);
            Assert.NotEqual(addResult.NewRecordedId, Guid.Empty);

            var request = new ApplicationService.ChangeActiveStatusTermRequest
            {
                Id = addResult.NewRecordedId
            };
            var result = sysAdminHttpClient.CallPostService<ChangeActiveStatusTermResponse>(ConstantsUrl.ChangeActiveStatusTermApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region Search
        [Fact]
        public void Search()
        {
            var request = new ApplicationService.SearchTermRequest
            {
                Accending = true,
                OrderedBy = "Id",
                PageIndex = 1,
                PageSize = 10,
                Caption = ""
            };

            var result = sysAdminHttpClient.CallPostService<SearchTermResponse>(ConstantsUrl.SearchTermApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
