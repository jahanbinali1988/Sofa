using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetLessonPlanByIdResponse : ResponseBase
    {
        public LessonPlanDto LessonPlan { get; set; }
    }
}
