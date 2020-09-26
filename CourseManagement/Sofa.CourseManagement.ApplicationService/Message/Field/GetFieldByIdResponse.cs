using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetFieldByIdResponse : ResponseBase
    {
        public GetFieldByIdResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetFieldByIdResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public FieldDto Field { get; set; }
    }
}
