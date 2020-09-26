using Sofa.CourseManagement.ApplicationServic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetSessionByIdResponse : ResponseBase
    {
        public SessionDto Session { get; set; }
    }
}
