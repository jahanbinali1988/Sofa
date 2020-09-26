namespace Sofa.CourseManagement.ApplicationService
{
    public interface ISessionService
    {
        AddSessionResponse AddSession(AddSessionRequest request);
        GetSessionByIdResponse Get(GetSessionByIdRequest request);
    }
}
