using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeleteTermResponse : ResponseBase
    {
        public DeleteTermResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeleteTermResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
