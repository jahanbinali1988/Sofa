namespace Sofa.SharedKernel.BaseClasses.Exceptions
{
    public class AccessDeniedException : BusinessException
    {
        public AccessDeniedException(string message) : base(message)
        {
        }
    }
}
