using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetPostByIdResponse : ResponseBase
    {
        public GetPostByIdResponse(PostDto post) : base(true, "")
        {
            Post = post;
        }

        public GetPostByIdResponse(bool successful, string message, string errorMessage) : base(successful, message, errorMessage)
        {
        }

        public GetPostByIdResponse(bool successful, string message) : base(successful, message, "")
        {
        }

        public PostDto Post { get; set; }
    }
}
