namespace Sofa.CourseManagement.ApplicationService
{
    public interface ITermService
    {
        AddTermResponse AddTerm(AddTermRequest request);
        GetTermByIdResponse Get(GetTermByIdRequest request);
    }
}
