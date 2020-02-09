using System;
using System.Collections.Generic;

namespace Sofa.SharedKernel.BaseClasses.Exceptions
{
    public class ValidationException : Exception
    {
        public IList<ValidationResult> ValidationResults { get; set; }

        public ValidationException(string message)
            : base(message)
        {
            ValidationResults = new List<ValidationResult>();
        }

        public ValidationException(string message, IList<ValidationResult> results) : base(message)
        {
            ValidationResults = results;
        }
    }
}
