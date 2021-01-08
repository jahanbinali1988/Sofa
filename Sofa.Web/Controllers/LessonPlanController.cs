using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.CourseManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonPlanController : ControllerBase
    {
        private readonly ILessonPlanService _lessonPlanService;
        public LessonPlanController(ILessonPlanService lessonPlanService)
        {
            this._lessonPlanService = lessonPlanService;
        }

        [Route("Add")]
        [HttpPost]
        [Authorize]
        public ActionResult<AddLessonPlanResponse> Add([FromBody] AddLessonPlanRequest request)
        {
            request.CommanderID = User.GetUserId();
            return _lessonPlanService.AddLessonPlan(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetLessonPlanByIdResponse> Get([FromQuery] string id)
        {
            GetLessonPlanByIdRequest request = new GetLessonPlanByIdRequest() { LessonPlanId = Guid.Parse(id) };
            return _lessonPlanService.Get(request);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult<GetAllLessonPlanResponse> GetAll([FromBody] GetAllLessonPlanRequest request)
        {
            var result = _lessonPlanService.GetAll(request);
            return result;
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ActionResult<DeleteLessonPlanResponse> Delete([FromBody] DeleteLessonPlanRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _lessonPlanService.Delete(request);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult<UpdateLessonPlanResponse> Update([FromBody] UpdateLessonPlanRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _lessonPlanService.Update(request);
            return result;
        }

        [HttpPost]
        [Route("ChangeActiveStatus")]
        [Authorize]
        public ActionResult<ChangeActiveStatusLessonPlanResponse> ChangeActiveStatus([FromBody] ChangeActiveStatusLessonPlanRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _lessonPlanService.ChangeActiveStatus(request);
            return result;
        }

        [HttpPost]
        [Route("Search")]
        [Authorize]
        public ActionResult<SearchLessonPlanResponse> Search([FromBody] SearchLessonPlanRequest request)
        {
            var result = _lessonPlanService.Search(request);
            return result;
        }

    }
}
