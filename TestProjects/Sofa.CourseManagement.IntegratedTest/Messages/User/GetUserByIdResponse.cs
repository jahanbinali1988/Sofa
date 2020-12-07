using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;

namespace Sofa.CourseManagement.IntegratedTest.Messages.User
{
    public class GetUserByIdResponse : ResponseBase
    {
        public UserDto User { get; set; }
    }
}
