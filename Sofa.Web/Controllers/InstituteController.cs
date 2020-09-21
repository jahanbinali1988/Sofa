using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        private IInstituteService instituteService;
        public InstituteController(IInstituteService instituteService)
        {
            this.instituteService = instituteService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddInstituteResponse> Add([FromBody]AddInstituteRequest request)
        {
            request.CommanderID = User.GetUserId();
            return instituteService.AddInstitute(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetInstituteByIdResponse> Get([FromQuery]string id)
        {
            GetInstituteByIdRequest request = new GetInstituteByIdRequest() { InstituteId = Guid.Parse(id) };
            return instituteService.Get(request);
        }
    }
}
