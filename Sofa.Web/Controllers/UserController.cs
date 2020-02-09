using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;

namespace Sofa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("Add")]
        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] AddUserRequest request)
        {
            request.CommanderID = User.GetUserId();
            var response = userService.AddUser(request);
            return new ObjectResult(response);
        }

        [Route("Get")]
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromBody] GetUserByIdRequest request)
        {
            var response = userService.Get(request);
            return new ObjectResult(response);
        }
    }
}
