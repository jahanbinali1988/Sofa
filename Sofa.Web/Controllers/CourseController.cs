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
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddCourseResponse> Add([FromBody] AddCourseRequest request)
        {
            request.CommanderID = User.GetUserId();
            return _courseService.AddCourse(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetCourseByIdResponse> Get([FromQuery] string id)
        {
            GetCourseByIdRequest request = new GetCourseByIdRequest() { CourseId = Guid.Parse(id) };
            return _courseService.Get(request);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult<GetAllCourseResponse> GetAll([FromBody] GetAllCourseRequest request)
        {
            var result = _courseService.GetAll(request);
            return result;
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ActionResult<DeleteCourseResponse> Delete([FromBody] DeleteCourseRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _courseService.Delete(request);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult<UpdateCourseResponse> Update([FromBody] UpdateCourseRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _courseService.Update(request);
            return result;
        }

        [HttpPost]
        [Route("ChangeActiveStatus")]
        [Authorize]
        public ActionResult<ChangeActiveStatusCourseResponse> ChangeActiveStatus([FromBody] ChangeActiveStatusCourseRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _courseService.ChangeActiveStatus(request);
            return result;
        }

        [HttpPost]
        [Route("Search")]
        [Authorize]
        public ActionResult<SearchCourseResponse> Search([FromBody] SearchCourseRequest request)
        {
            var result = _courseService.Search(request);
            return result;
        }
    }
}
