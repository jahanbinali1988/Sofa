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
        private IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<GetPostByIdResponse> Get([FromQuery]string id)
        {
            GetPostByIdRequest request = new GetPostByIdRequest() { PostId = Guid.Parse(id) };
            return this.postService.Get(request);
        }

        // POST api/values
        [HttpPost]
        public AddPostResponse Post([FromBody] AddPostRequest request)
        {
            return this.postService.AddPost(request);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
