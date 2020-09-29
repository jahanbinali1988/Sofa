using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeleteSessionResponse : ResponseBase
    {
        public DeleteSessionResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeleteSessionResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
