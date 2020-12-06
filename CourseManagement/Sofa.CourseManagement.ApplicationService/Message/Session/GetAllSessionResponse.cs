using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllSessionResponse : ResponseBase
    {
        public GetAllSessionResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetAllSessionResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<SessionDto> Sessions { get; set; }
    }
}
