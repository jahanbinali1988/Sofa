using Sofa.CourseManagement.ApplicationService;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetLessonPlanByIdResponse : ResponseBase
    {
        public LessonPlanDto LessonPlan { get; set; }
    }
}
