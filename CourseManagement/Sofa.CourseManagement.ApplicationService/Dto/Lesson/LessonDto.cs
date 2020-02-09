using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public Guid LessonPlanId { get; set; }
        public string LessonPlanCaption { get; set; }
        public bool IsActive { get; set; }
    }
}
