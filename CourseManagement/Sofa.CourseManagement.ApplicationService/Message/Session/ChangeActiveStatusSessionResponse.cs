using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class ChangeActiveStatusSessionResponse : ResponseBase
    {
        public ChangeActiveStatusSessionResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public ChangeActiveStatusSessionResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
