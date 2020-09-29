using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeleteCourseResponse : ResponseBase
    {
        public DeleteCourseResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeleteCourseResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
