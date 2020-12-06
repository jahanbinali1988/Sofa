namespace Sofa.CourseManagement.ApplicationService
{
    public interface IInstituteService
    {
        AddInstituteResponse AddInstitute(AddInstituteRequest request);
        GetInstituteByIdResponse Get(GetInstituteByIdRequest request);
        GetAllInstituteResponse GetAll(GetAllInstituteRequest request);
        UpdateInstituteResponse Update(UpdateInstituteRequest request);
        DeleteInstituteResponse Delete(DeleteInstituteRequest request);
        ChangeActiveStatusInstituteResponse ChangeActiveStatus(ChangeActiveStatusInstituteRequest request);
        SearchInstituteResponse Search(SearchInstituteRequest request);
    }
}
