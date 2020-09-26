using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class LessonPlanDto
    {
        public Guid Id { get; set; }
        public LevelEnum Level { get; set; }
        public string LevelCaption { get; set; }
        public bool IsActive { get; set; }

        public Guid SessionId { get; set; }
    }
}
