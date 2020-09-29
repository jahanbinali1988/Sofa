using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateCourseResponse : ResponseBase
    {
        public UpdateCourseResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateCourseResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
