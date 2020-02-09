using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class LessonPlanDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public LevelEnum Level { get; set; }
        public string LevelCaption { get; set; }
    }
}
