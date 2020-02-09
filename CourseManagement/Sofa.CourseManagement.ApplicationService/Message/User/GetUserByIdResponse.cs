using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetUserByIdResponse : ResponseBase
    {
        public GetUserByIdResponse(UserDto user) : base(true, "")
        {
            User = user;
        }

        public GetUserByIdResponse(bool successful, string message, string errorMessage) : base(successful, message, errorMessage)
        {
        }

        public GetUserByIdResponse(bool successful, string message) : base(successful, message, "")
        {
        }

        public UserDto User { get; set; }
    }
}
