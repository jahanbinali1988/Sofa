using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateUserResponse : ResponseBase
    {
        public UpdateUserResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateUserResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
