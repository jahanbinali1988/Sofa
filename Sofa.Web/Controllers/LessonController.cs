using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.ApplicationService;

namespace Sofa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private ILessonService lessonService;
        public LessonController(ILessonService lessonService)
        {
            this.lessonService = lessonService;
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
        public ActionResult<GetLessonByIdResponse> Get([FromQuery]string id)
        {
            GetLessonByIdRequest request = new GetLessonByIdRequest() { LessonId = Guid.Parse(id) };
            return this.lessonService.Get(request);
        }

        // POST api/values
        [HttpPost]
        public AddLessonResponse Post([FromBody] AddLessonRequest request)
        {
            return this.lessonService.AddLesson(request);
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
