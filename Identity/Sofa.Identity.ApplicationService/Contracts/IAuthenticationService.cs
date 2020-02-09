namespace Sofa.Identity.ApplicationService
{
    public interface IAuthenticationService
    {
        GetUserCredentialValidationStatusResponse GetUserCredentialValidationStatus(GetUserCredentialValidationStatusRequest request);
    }
}
