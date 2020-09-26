namespace Sofa.CourseManagement.ApplicationService
{
    public interface IFieldService
    {
        AddFieldResponse AddField(AddFieldRequest request);
        GetFieldByIdResponse Get(GetFieldByIdRequest request);
    }
}
