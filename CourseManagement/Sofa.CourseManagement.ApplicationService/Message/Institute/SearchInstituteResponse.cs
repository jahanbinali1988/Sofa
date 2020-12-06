using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchInstituteResponse : ResponseBase
    {
        public SearchInstituteResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public SearchInstituteResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<InstituteDto> Institutes { get; set; }
    }
}
