using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchFieldResponse : ResponseBase
    {
        public SearchFieldResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public SearchFieldResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<FieldDto> Fields { get; set; }
    }
}
