using System;
using System.Collections.Generic;
using System.Text;

namespace Sofa.SharedKernel.BaseClasses
{
    public class ValidationResponse
    {
        public ValidationResponse()
        {
            Results = new List<ValidationResult>();
        }

        public IList<ValidationResult> Results { get; set; }
        public bool IsValid { get; set; }
    }
}
