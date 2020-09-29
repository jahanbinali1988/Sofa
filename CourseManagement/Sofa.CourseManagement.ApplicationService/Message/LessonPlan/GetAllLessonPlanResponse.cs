using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllLessonPlanResponse : ResponseBase
    {
        public GetAllLessonPlanResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetAllLessonPlanResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<LessonPlanDto> LessonPlans { get; set; }
    }
}
