using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllCourseResponse : ResponseBase
    {
        public GetAllCourseResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetAllCourseResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<CourseDto> Courses { get; set; }
    }
}
