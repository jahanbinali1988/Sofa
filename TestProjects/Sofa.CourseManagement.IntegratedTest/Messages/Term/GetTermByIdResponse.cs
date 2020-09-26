using Sofa.CourseManagement.ApplicationService;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetTermByIdResponse : ResponseBase
    {
        public TermDto Term { get; set; }
    }
}
