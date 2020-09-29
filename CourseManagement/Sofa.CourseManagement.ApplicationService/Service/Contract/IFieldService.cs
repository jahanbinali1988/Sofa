namespace Sofa.CourseManagement.ApplicationService
{
    public interface IFieldService
    {
        AddFieldResponse AddField(AddFieldRequest request);
        GetFieldByIdResponse Get(GetFieldByIdRequest request);
        GetAllFieldResponse GetAll(GetAllFieldRequest request);
        UpdateFieldResponse Update(UpdateFieldRequest request);
        DeleteFieldResponse Delete(DeleteFieldRequest request);
    }
}
