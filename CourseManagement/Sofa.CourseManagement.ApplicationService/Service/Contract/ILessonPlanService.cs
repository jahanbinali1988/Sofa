namespace Sofa.CourseManagement.ApplicationService
{
    public interface ILessonPlanService
    {
        AddLessonPlanResponse AddLessonPlan(AddLessonPlanRequest request);
        GetLessonPlanByIdResponse Get(GetLessonPlanByIdRequest request);
    }
}
