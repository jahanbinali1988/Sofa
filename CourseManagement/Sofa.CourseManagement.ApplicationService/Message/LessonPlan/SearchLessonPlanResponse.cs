using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchLessonPlanResponse : ResponseBase
    {
        public SearchLessonPlanResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public SearchLessonPlanResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<LessonPlanDto> LessonPlans { get; set; }
    }
}
