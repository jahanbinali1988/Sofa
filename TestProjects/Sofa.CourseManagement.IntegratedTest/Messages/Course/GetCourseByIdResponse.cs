using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetCourseByIdResponse : ResponseBase
    {
        public CourseDto Course { get; set; }
    }
}
