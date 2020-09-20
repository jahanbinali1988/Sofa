using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetInstituteByIdResponse : ResponseBase
    {
        public GetInstituteByIdResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetInstituteByIdResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public InstituteDto Institute { get; set; }
    }
}
