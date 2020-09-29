using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateLessonPlanResponse : ResponseBase
    {
        public UpdateLessonPlanResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateLessonPlanResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
