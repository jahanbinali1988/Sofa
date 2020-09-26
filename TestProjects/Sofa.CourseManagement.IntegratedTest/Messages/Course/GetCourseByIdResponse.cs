using Sofa.CourseManagement.ApplicationService;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetCourseByIdResponse : ResponseBase
    {
        public CourseDto Course { get; set; }
    }
}
