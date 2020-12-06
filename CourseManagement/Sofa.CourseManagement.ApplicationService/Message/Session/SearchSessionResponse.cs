using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchSessionResponse : ResponseBase
    {
        public SearchSessionResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public SearchSessionResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<SessionDto> Sessions { get; set; }
    }
}
