using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllUserResponse : ResponseBase
    {
        public GetAllUserResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetAllUserResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
