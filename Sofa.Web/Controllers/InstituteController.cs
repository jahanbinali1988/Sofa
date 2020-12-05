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
        private readonly IInstituteService _instituteService;
        public InstituteController(IInstituteService instituteService)
        {
            this._instituteService = instituteService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddInstituteResponse> Add([FromBody] AddInstituteRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _instituteService.AddInstitute(request);
            return result;
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult<GetInstituteByIdResponse> Get([FromQuery] string id)
        {
            GetInstituteByIdRequest request = new GetInstituteByIdRequest() { InstituteId = Guid.Parse(id) };
            return _instituteService.Get(request);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult<GetAllInstituteResponse> GetAll([FromBody] GetAllInstituteRequest request)
        {
            var result = _instituteService.GetAll(request);
            return result;
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ActionResult<DeleteInstituteResponse> Delete([FromBody] DeleteInstituteRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _instituteService.Delete(request);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult<UpdateInstituteResponse> Update([FromBody] UpdateInstituteRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _instituteService.Update(request);
            return result;
        }
    }
}
