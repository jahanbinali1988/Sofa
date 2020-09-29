using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeleteFieldResponse : ResponseBase
    {
        public DeleteFieldResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeleteFieldResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
