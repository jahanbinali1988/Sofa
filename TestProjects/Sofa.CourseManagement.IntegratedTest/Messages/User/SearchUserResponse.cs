using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class SearchUserResponse : ResponseBase
    {
        public IEnumerable<UserDto> Users { get; set; }
    }
}
