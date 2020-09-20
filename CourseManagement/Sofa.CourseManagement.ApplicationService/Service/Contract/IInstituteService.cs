namespace Sofa.CourseManagement.ApplicationService
{
    public interface IInstituteService
    {
        AddInstituteResponse AddInstitute(AddInstituteRequest request);
        GetInstituteByIdResponse Get(GetInstituteByIdRequest request);
    }
}
