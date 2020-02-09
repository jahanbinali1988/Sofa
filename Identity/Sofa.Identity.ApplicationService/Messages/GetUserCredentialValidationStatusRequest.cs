using Sofa.SharedKernel.BaseClasses;

namespace Sofa.Identity.ApplicationService
{
    public class GetUserCredentialValidationStatusRequest : RequestBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
