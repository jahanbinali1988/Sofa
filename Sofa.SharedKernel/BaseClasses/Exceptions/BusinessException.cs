using System;

namespace Sofa.SharedKernel.BaseClasses.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
