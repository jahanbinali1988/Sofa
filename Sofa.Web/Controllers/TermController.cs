using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private readonly ITermService _termService;
        public TermController(ITermService termService)
        {
            this._termService = termService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddTermResponse> Add([FromBody] AddTermRequest request)
        {
            request.CommanderID = User.GetUserId();
            return _termService.AddTerm(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetTermByIdResponse> Get([FromQuery] string id)
        {
            GetTermByIdRequest request = new GetTermByIdRequest() { TermId = Guid.Parse(id) };
            return _termService.Get(request);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult<GetAllTermResponse> GetAll([FromBody] GetAllTermRequest request)
        {
            var result = _termService.GetAll(request);
            return result;
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ActionResult<DeleteTermResponse> Delete([FromBody] DeleteTermRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _termService.Delete(request);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult<UpdateTermResponse> Update([FromBody] UpdateTermRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _termService.Update(request);
            return result;
        }
    }
}
