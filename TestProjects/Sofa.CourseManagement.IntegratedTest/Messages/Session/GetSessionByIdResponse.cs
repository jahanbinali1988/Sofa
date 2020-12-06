using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetSessionByIdResponse : ResponseBase
    {
        public SessionDto Session { get; set; }
    }
}
