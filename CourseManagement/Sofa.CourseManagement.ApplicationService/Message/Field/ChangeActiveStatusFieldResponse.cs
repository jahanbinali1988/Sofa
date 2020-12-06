using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class ChangeActiveStatusFieldResponse : ResponseBase
    {
        public ChangeActiveStatusFieldResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public ChangeActiveStatusFieldResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
