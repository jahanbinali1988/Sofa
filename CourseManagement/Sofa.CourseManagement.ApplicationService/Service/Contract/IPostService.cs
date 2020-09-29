namespace Sofa.CourseManagement.ApplicationService
{
    public interface IPostService
    {
        AddPostResponse AddPost(AddPostRequest request);
        GetPostByIdResponse Get(GetPostByIdRequest request);
        GetAllPostResponse GetAll(GetAllPostRequest request);
        UpdatePostResponse Update(UpdatePostRequest request);
        DeletePostResponse Delete(DeletePostRequest request);
    }
}
