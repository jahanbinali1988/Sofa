using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetPostByIdResponse : ResponseBase
    {
        public PostDto Post { get; set; }
    }
}
