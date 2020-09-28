using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddCourseResponse : ResponseBase
    {
        public AddCourseResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AddCourseResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public Guid NewRecordedId { get; set; }
    }
}
