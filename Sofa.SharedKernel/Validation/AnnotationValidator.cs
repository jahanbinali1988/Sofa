using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sofa.SharedKernel.Validation
{
    public static class AnnotationValidator
    {
        public static ValidationResponse Validate(this object obj)
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(obj, context, results, true);

            if (isValid)
                return new ValidationResponse { IsValid = true };

            var res = new ValidationResponse { IsValid = false };

            foreach (var item in results)
            {
                res.Results.Add(new BaseClasses.ValidationResult(item.MemberNames.ToArray(), item.ErrorMessage, false));
            }

            return res;
        }
    }
}
