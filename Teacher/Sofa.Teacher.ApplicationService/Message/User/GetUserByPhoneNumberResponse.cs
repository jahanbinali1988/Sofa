using Sofa.SharedKernel.BaseClasses;

namespace Sofa.Teacher.ApplicationService
{
    public class GetUserByPhoneNumberResponse : ResponseBase
    {
        public GetUserByPhoneNumberResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetUserByPhoneNumberResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public UserDto User { get; set; }
    }
}
