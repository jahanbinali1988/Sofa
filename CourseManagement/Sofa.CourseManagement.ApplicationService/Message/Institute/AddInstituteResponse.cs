using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddInstituteResponse : ResponseBase
    {
        public AddInstituteResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AddInstituteResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public Guid NewRecordedId { get; set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
