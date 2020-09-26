using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private ISessionService sessionService;
        public SessionController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddSessionResponse> Add([FromBody]AddSessionRequest request)
        {
            request.CommanderID = User.GetUserId();
            return sessionService.AddSession(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetSessionByIdResponse> Get([FromQuery]string id)
        {
            GetSessionByIdRequest request = new GetSessionByIdRequest() { SessionId = Guid.Parse(id) };
            return sessionService.Get(request);
        }
    }
}
