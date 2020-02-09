using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetLessonPlanByIdResponse : ResponseBase
    {
        public GetLessonPlanByIdResponse(LessonPlanDto lessonPlan) : base(true, "")
        {
            LessonPlan = lessonPlan;
        }

        public GetLessonPlanByIdResponse(bool successful, string message, string errorMessage) : base(successful, message, errorMessage)
        {
        }

        public GetLessonPlanByIdResponse(bool successful, string message) : base(successful, message, "")
        {
        }

        public LessonPlanDto LessonPlan { get; set; }
    }
}
