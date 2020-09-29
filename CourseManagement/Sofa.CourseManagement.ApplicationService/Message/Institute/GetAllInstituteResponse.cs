using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllInstituteResponse : ResponseBase
    {
        public GetAllInstituteResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetAllInstituteResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<InstituteDto> Institutes { get; set; }
    }
}
