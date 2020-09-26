using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetTermByIdResponse : ResponseBase
    {
        public GetTermByIdResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetTermByIdResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public TermDto Term { get; set; }
    }
}
