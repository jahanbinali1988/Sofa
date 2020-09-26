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
        private ITermService termService;
        public TermController(ITermService termService)
        {
            this.termService = termService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddTermResponse> Add([FromBody]AddTermRequest request)
        {
            request.CommanderID = User.GetUserId();
            return termService.AddTerm(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetTermByIdResponse> Get([FromQuery]string id)
        {
            GetTermByIdRequest request = new GetTermByIdRequest() { TermId = Guid.Parse(id) };
            return termService.Get(request);
        }
    }
}
