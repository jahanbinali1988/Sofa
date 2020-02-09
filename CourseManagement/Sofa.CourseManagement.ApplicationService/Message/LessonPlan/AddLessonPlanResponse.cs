using System;
using System.Collections.Generic;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddLessonPlanResponse : ResponseBase
    {
        public AddLessonPlanResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AddLessonPlanResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
        public Guid NewRecordedId { get; set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
