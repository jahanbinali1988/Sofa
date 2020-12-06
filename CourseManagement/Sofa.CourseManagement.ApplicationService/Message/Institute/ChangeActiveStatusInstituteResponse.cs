using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class ChangeActiveStatusInstituteResponse : ResponseBase
    {
        public ChangeActiveStatusInstituteResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public ChangeActiveStatusInstituteResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
