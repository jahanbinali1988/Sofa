using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeletePostResponse : ResponseBase
    {
        public DeletePostResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeletePostResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
