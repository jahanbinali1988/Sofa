using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetAllCourseResponse : ResponseBase
    {
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}
