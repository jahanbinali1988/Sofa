using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using System.Linq;

namespace Sofa.SharedKernel
{
    public static class ValidationResponseExtension
    {
        public static void ThrowIfNotValid(this ValidationResponse response, bool combineMessages = false)
        {
            if (!response.IsValid)
                if (combineMessages)
                    throw new ValidationException(string.Join("\r\n", response.Results.Select(x => x.ValidationMessage)), response.Results);
                else
                    throw new ValidationException("به دلیل بروز خطا امکان تکمیل عملیات وجود ندارد.", response.Results);
        }

        public static void ThrowIfNotValid(this ValidationResponse response, string message)
        {
            if (!response.IsValid)
                throw new ValidationException(message, response.Results);
        }
    }
}
