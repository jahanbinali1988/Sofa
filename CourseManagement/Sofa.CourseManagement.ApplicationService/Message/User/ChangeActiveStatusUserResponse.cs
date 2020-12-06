using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class ChangeActiveStatusUserResponse : ResponseBase
    {
        public ChangeActiveStatusUserResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public ChangeActiveStatusUserResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
