using System;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddLessonResponse : AddResponseBase
    {
        public AddLessonResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
            this.NewRecordedId = newRecordedId;
        }
        public AddLessonResponse(Guid newRecordedId) : base(newRecordedId)
        {
            this.NewRecordedId = newRecordedId;
        }
    }
}
