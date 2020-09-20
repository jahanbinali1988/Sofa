using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sofa.SharedKernel.Validation
{
    public class GuidValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is Guid))
                return null;

            var id = (Guid)value;
            if (id == Guid.Empty)
            {
                var msg = ErrorMessage ?? $"{validationContext.DisplayName} is Empty";
                return new ValidationResult(msg, new List<string> { validationContext.MemberName });
            }

            return null;
        }
    }
}
