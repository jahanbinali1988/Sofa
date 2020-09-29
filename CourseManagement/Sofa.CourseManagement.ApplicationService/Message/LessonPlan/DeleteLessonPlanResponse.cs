using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeleteLessonPlanResponse : ResponseBase
    {
        public DeleteLessonPlanResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeleteLessonPlanResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
