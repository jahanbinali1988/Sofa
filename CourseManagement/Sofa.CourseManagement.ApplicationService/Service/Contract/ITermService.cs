namespace Sofa.CourseManagement.ApplicationService
{
    public interface ITermService
    {
        AddTermResponse AddTerm(AddTermRequest request);
        GetTermByIdResponse Get(GetTermByIdRequest request);
        GetAllTermResponse GetAll(GetAllTermRequest request);
        UpdateTermResponse Update(UpdateTermRequest request);
        DeleteTermResponse Delete(DeleteTermRequest request);
        ChangeActiveStatusTermResponse ChangeActiveStatus(ChangeActiveStatusTermRequest request);
        SearchTermResponse Search(SearchUserRequest request);
    }
}
