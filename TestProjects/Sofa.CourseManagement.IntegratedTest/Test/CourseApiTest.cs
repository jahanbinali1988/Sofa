using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
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
            var url = ConstantsUrl.GetCourseByIdApiUrl + "";
            var result = unknownHttpClient.CallGetService<Messages.GetCourseByIdResponse>(url);
            Assert.True(result.IsSuccess);
        }
        #endregion

        #region AddCourse
        [Fact]
        public void Add()
        {
            var request = new AddCourseRequest()
            {

            };

            var result = sysAdminHttpClient.CallPostService<Messages.AddCourseResponse>(ConstantsUrl.AddCourseApiUrl, request);
            Assert.True(result.IsSuccess);
        }
        #endregion
    }
}
