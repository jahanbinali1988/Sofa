using Sofa.SharedKernel.BaseClasses;

namespace Sofa.Identity.ApplicationService
{
    public class GetUserCredentialValidationStatusResponse : ResponseBase
    {
        public GetUserCredentialValidationStatusResponse(bool isSuccess, string message) : base(isSuccess, message)
        {

        }

        public GetUserCredentialValidationStatusResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {

        }
        public bool CredentialIsValid { get; set; }
        public string UserTitle { get; set; }
        public string UserRole { get; set; }
        public object UserId { get; set; }
    }
}
