using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateInstituteResponse : ResponseBase
    {
        public UpdateInstituteResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateInstituteResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
