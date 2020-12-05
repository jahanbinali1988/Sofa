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
        private readonly IFieldService _fieldService;
        public FieldController(IFieldService fieldService)
        {
            this._fieldService = fieldService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public ActionResult<AddFieldResponse> Add([FromBody] AddFieldRequest request)
        {
            request.CommanderID = User.GetUserId();
            return _fieldService.AddField(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetFieldByIdResponse> Get([FromQuery] string id)
        {
            GetFieldByIdRequest request = new GetFieldByIdRequest() { FieldId = Guid.Parse(id) };
            return _fieldService.Get(request);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult<GetAllFieldResponse> GetAll([FromBody] GetAllFieldRequest request)
        {
            var result = _fieldService.GetAll(request);
            return result;
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ActionResult<DeleteFieldResponse> Delete([FromBody] DeleteFieldRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _fieldService.Delete(request);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult<UpdateFieldResponse> Update([FromBody] UpdateFieldRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _fieldService.Update(request);
            return result;
        }
    }
}
