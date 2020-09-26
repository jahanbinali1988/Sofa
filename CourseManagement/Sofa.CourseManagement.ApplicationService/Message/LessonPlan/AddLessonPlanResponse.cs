using System;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddLessonPlanResponse : AddResponseBase
    {
        public AddLessonPlanResponse()
        {
        }

        public AddLessonPlanResponse(Guid newRecordedId) : base(newRecordedId)
        {
        }

        public AddLessonPlanResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
        }
    }
}
