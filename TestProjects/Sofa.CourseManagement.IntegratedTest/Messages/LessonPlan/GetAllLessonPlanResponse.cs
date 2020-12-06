using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetAllLessonPlanResponse : ResponseBase
    {
        public IEnumerable<LessonPlanDto> LessonPlans { get; set; }
    }
}
