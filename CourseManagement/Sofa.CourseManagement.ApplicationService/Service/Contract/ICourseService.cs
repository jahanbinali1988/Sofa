namespace Sofa.CourseManagement.ApplicationService
{
    public interface ICourseService
    {
        AddCourseResponse AddCourse(AddCourseRequest request);
        GetCourseByIdResponse Get(GetCourseByIdRequest request);
        GetAllCourseResponse GetAll(GetAllCourseRequest request);
        UpdateCourseResponse Update(UpdateCourseRequest request);
        DeleteCourseResponse Delete(DeleteCourseRequest request);
    }
}
