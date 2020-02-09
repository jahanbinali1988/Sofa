namespace Sofa.CourseManagement.ApplicationService
{
    public interface IUserService
    {
        AddUserResponse AddUser(AddUserRequest request);
        GetUserByIdResponse Get(GetUserByIdRequest request);
    }
}
