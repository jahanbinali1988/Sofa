namespace Sofa.CourseManagement.ApplicationService
{
    public interface IUserService
    {
        AddUserResponse AddUser(AddUserRequest request);
        GetUserByIdResponse Get(GetUserByIdRequest request);
        GetAllUserResponse GetAll(GetAllUserRequest request);
        UpdateUserResponse Update(UpdateUserRequest request);
        DeleteUserResponse Delete(DeleteUserRequest request);
    }
}
