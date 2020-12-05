using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.Teacher.ApplicationService
{
    public class AddUserResponse : ResponseBase
    {
        public AddUserResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AddUserResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
        public Guid NewRecordedId { get; set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
