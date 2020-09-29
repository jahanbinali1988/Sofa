using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeleteUserResponse : ResponseBase
    {
        public DeleteUserResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeleteUserResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
