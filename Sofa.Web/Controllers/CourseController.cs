using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddCourseResponse> Add([FromBody]AddCourseRequest request)
        {
            request.CommanderID = User.GetUserId();
            return courseService.AddCourse(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetCourseByIdResponse> Get([FromQuery]string id)
        {
            GetCourseByIdRequest request = new GetCourseByIdRequest() { CourseId = Guid.Parse(id) };
            return courseService.Get(request);
        }
    }
}
