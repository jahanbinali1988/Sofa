using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class ChangeActiveStatusCourseResponse : ResponseBase
    {
        public ChangeActiveStatusCourseResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public ChangeActiveStatusCourseResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
