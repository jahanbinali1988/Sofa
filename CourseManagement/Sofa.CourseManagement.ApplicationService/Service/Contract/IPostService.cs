namespace Sofa.CourseManagement.ApplicationService
{
    public interface IPostService
    {
        AddPostResponse AddPost(AddPostRequest request);
        GetPostByIdResponse Get(GetPostByIdRequest request);
    }
}
