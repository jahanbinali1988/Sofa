using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonPlanController : ControllerBase
    {
        private ILessonPlanService lessonPlanService;
        public LessonPlanController(ILessonPlanService lessonPlanService)
        {
            this.lessonPlanService = lessonPlanService;
        }

        [Route("Add")]
        [HttpPost]
        [Authorize]
        public ActionResult<AddLessonPlanResponse> Add([FromBody] AddLessonPlanRequest request)
        {
            request.CommanderID = User.GetUserId();
            return lessonPlanService.AddLessonPlan(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetLessonPlanByIdResponse> Get([FromQuery]string id)
        {
            GetLessonPlanByIdRequest request = new GetLessonPlanByIdRequest() { LessonPlanId = Guid.Parse(id) };
            return lessonPlanService.Get(request);
        }

        //[Route("Update")]
        //[HttpPost]
        //public IActionResult Update([FromBody] UpdateDeviceRequest request)
        //{
        //    request.CommanderID = User.GetUserId();
        //    var response = deviceService.Update(request);
        //    return new ObjectResult(response);
        //}

        //[Route("Delete")]
        //[HttpPost]
        //public IActionResult Delete([FromBody] DeleteDeviceRequest request)
        //{
        //    request.CommanderID = User.GetUserId();
        //    var response = deviceService.Delete(request);
        //    return new ObjectResult(response);
        //}

        //[Route("GetById")]
        //[HttpPost]
        //public IActionResult GetById([FromBody] GetDeviceRequest request)
        //{
        //    request.CommanderID = User.GetUserId();
        //    var response = deviceService.Get(request);
        //    return new ObjectResult(response);
        //}

    }
}
