using Sofa.CourseManagement.ApplicationServic;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetSessionByIdResponse : ResponseBase
    {
        public GetSessionByIdResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetSessionByIdResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public SessionDto MyProperty { get; set; }
    }
}
