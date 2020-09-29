using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllFieldResponse : ResponseBase
    {
        public GetAllFieldResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetAllFieldResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<FieldDto> Fields { get; set; }
    }
}
