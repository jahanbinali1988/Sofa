using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;
using System;

namespace Sofa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [Route("Add")]
        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] AddUserRequest request)
        {
            request.CommanderID = User.GetUserId();
            var response = _userService.AddUser(request);
            return new ObjectResult(response);
        }

        [Route("Get")]
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] string id)
        {
            var request = new GetUserByIdRequest() { UserId = Guid.Parse(id) };
            var response = _userService.Get(request);
            return new ObjectResult(response);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult<GetAllUserResponse> GetAll([FromBody] GetAllUserRequest request)
        {
            var result = _userService.GetAll(request);
            return result;
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ActionResult<DeleteUserResponse> Delete([FromBody] DeleteUserRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _userService.Delete(request);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult<UpdateUserResponse> Update([FromBody] UpdateUserRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _userService.Update(request);
            return result;
        }
    }
}
