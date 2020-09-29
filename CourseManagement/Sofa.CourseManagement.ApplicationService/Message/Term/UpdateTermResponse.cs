using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateTermResponse : ResponseBase
    {
        public UpdateTermResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateTermResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
