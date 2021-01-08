using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.CourseManagement.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            this._sessionService = sessionService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddSessionResponse> Add([FromBody] AddSessionRequest request)
        {
            request.CommanderID = User.GetUserId();
            return _sessionService.AddSession(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetSessionByIdResponse> Get([FromQuery] string id)
        {
            GetSessionByIdRequest request = new GetSessionByIdRequest() { SessionId = Guid.Parse(id) };
            return _sessionService.Get(request);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult<GetAllSessionResponse> GetAll([FromBody] GetAllSessionRequest request)
        {
            var result = _sessionService.GetAll(request);
            return result;
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ActionResult<DeleteSessionResponse> Delete([FromBody] DeleteSessionRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _sessionService.Delete(request);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult<UpdateSessionResponse> Update([FromBody] UpdateSessionRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _sessionService.Update(request);
            return result;
        }

        [HttpPost]
        [Route("ChangeActiveStatus")]
        [Authorize]
        public ActionResult<ChangeActiveStatusSessionResponse> ChangeActiveStatus([FromBody] ChangeActiveStatusSessionRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _sessionService.ChangeActiveStatus(request);
            return result;
        }

        [HttpPost]
        [Route("Search")]
        [Authorize]
        public ActionResult<SearchSessionResponse> Search([FromBody] SearchSessionRequest request)
        {
            var result = _sessionService.Search(request);
            return result;
        }
    }
}
