using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private IFieldService fieldService;
        public FieldController(IFieldService fieldService)
        {
            this.fieldService = fieldService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddFieldResponse> Add([FromBody]AddFieldRequest request)
        {
            request.CommanderID = User.GetUserId();
            return fieldService.AddField(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetFieldByIdResponse> Get([FromQuery]string id)
        {
            GetFieldByIdRequest request = new GetFieldByIdRequest() { FieldId = Guid.Parse(id) };
            return fieldService.Get(request);
        }
    }
}
