using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;

namespace Sofa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        [Route("Add")]
        [HttpPost]
        [Authorize]
        public ActionResult<AddPostResponse> Add([FromBody] AddPostRequest request)
        {
            request.CommanderID = User.GetUserId();
            return _postService.AddPost(request);
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<GetPostByIdResponse> Get([FromQuery] string id)
        {
            GetPostByIdRequest request = new GetPostByIdRequest() { PostId = Guid.Parse(id) };
            return _postService.Get(request);
        }

        [HttpPost]
        [Route("GetAll")]
        [Authorize]
        public ActionResult<GetAllPostResponse> GetAll([FromBody] GetAllPostRequest request)
        {
            var result = _postService.GetAll(request);
            return result;
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public ActionResult<DeletePostResponse> Delete([FromBody] DeletePostRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _postService.Delete(request);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult<UpdatePostResponse> Update([FromBody] UpdatePostRequest request)
        {
            request.CommanderID = User.GetUserId();
            var result = _postService.Update(request);
            return result;
        }
    }
}
