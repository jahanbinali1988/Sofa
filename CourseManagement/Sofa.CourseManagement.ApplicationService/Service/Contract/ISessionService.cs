namespace Sofa.CourseManagement.ApplicationService
{
    public interface ISessionService
    {
        AddSessionResponse AddSession(AddSessionRequest request);
        GetSessionByIdResponse Get(GetSessionByIdRequest request);
        GetAllSessionResponse GetAll(GetAllSessionRequest request);
        UpdateSessionResponse Update(UpdateSessionRequest request);
        DeleteSessionResponse Delete(DeleteSessionRequest request);
        ChangeActiveStatusSessionResponse ChangeActiveStatus(ChangeActiveStatusSessionRequest request);
        SearchSessionResponse Search(SearchSessionRequest request);
    }
}
