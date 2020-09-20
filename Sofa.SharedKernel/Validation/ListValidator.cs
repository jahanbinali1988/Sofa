using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sofa.SharedKernel.Validation
{
    public class ListValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IEnumerable;
            if (list == null)
                return new ValidationResult($"{validationContext.DisplayName} is Empty", new List<string>() { validationContext.MemberName });

            foreach (var item in list)
            {
                if (item.Equals(null))
                {
                    var msg = ErrorMessage ?? $"{validationContext.DisplayName} is Empty";
                    return new ValidationResult(msg, new List<string> { validationContext.MemberName });
                }
            }

            return null;
        }
    }
}
