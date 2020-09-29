using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateFieldResponse : ResponseBase
    {
        public UpdateFieldResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateFieldResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
