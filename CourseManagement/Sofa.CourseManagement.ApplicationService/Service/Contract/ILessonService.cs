namespace Sofa.CourseManagement.ApplicationService
{
    public interface ILessonService
    {
        AddLessonResponse AddLesson(AddLessonRequest request);
        GetLessonByIdResponse Get(GetLessonByIdRequest request);
    }
}
