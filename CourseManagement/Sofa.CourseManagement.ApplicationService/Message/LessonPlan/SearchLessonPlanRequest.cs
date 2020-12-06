using Sofa.SharedKernel.BaseClasses.Message;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchLessonPlanRequest : RequestWithPaging
    {
        public string Caption { get; set; }
    }
}
