using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateSessionResponse : ResponseBase
    {
        public UpdateSessionResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateSessionResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
