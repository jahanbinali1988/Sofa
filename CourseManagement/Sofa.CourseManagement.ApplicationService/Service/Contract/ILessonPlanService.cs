namespace Sofa.CourseManagement.ApplicationService
{
    public interface ILessonPlanService
    {
        AddLessonPlanResponse AddLessonPlan(AddLessonPlanRequest request);
        GetLessonPlanByIdResponse Get(GetLessonPlanByIdRequest request);
        GetAllLessonPlanResponse GetAll(GetAllLessonPlanRequest request);
        UpdateLessonPlanResponse Update(UpdateLessonPlanRequest request);
        DeleteLessonPlanResponse Delete(DeleteLessonPlanRequest request);
        ChangeActiveStatusLessonPlanResponse ChangeActiveStatus(ChangeActiveStatusLessonPlanRequest request);
        SearchLessonPlanResponse Search(SearchLessonPlanRequest request);
    }
}
