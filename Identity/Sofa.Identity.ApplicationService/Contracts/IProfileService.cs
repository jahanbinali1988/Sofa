namespace Sofa.Identity.ApplicationService
{
    public interface IProfileService
    {
        GetCurrentUserInfoResponse GetCurrentUserInfo(GetCurrentUserInfoRequest request);
    }
}
