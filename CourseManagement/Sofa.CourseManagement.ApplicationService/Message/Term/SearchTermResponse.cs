using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchTermResponse : ResponseBase
    {
        public SearchTermResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public SearchTermResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<TermDto> Terms { get; set; }
    }
}
