using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetLessonByIdResponse : ResponseBase
    {
        public GetLessonByIdResponse(LessonDto lesson) : base(true, "")
        {
            Lesson = lesson;
        }

        public GetLessonByIdResponse(bool successful, string message, string errorMessage) : base(successful, message, errorMessage)
        {
        }

        public GetLessonByIdResponse(bool successful, string message) : base(successful, message, "")
        {
        }

        public LessonDto Lesson { get; set; }
    }
}
