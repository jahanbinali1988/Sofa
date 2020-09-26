using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetCourseByIdResponse : ResponseBase
    {
        public GetCourseByIdResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetCourseByIdResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public CourseDto Course { get; set; }
    }
}
