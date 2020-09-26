using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddCourseResponse : AddResponseBase
    {
        public AddCourseResponse()
        {
        }

        public AddCourseResponse(Guid newRecordedId) : base(newRecordedId)
        {
        }

        public AddCourseResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
        }
    }
}
