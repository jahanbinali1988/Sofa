using Sofa.CourseManagement.ApplicationService;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetPostByIdResponse : ResponseBase
    {
        public PostDto Post { get; set; }
    }
}
