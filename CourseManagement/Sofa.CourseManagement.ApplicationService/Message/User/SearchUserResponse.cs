using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchUserResponse : ResponseBase
    {
        public SearchUserResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public SearchUserResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
