using Sofa.SharedKernel.BaseClasses;

namespace Sofa.Identity.ApplicationService
{
    public class GetCurrentUserInfoResponse : ResponseBase
    {
        public GetCurrentUserInfoResponse(bool isSuccess, string message) : base(isSuccess, message)
        {

        }

        public GetCurrentUserInfoResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {

        }
        public UserInfoViewModel UserProfile { get; set; }
    }
}
