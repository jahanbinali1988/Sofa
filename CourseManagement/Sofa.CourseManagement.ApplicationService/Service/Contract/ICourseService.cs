namespace Sofa.CourseManagement.ApplicationService
{
    public interface ICourseService
    {
        AddCourseResponse AddCourse(AddCourseRequest request);
        GetCourseByIdResponse Get(GetCourseByIdRequest request);
    }
}
