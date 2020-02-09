using System;

namespace Sofa.Events.Lesson
{
    public class RegisterLessonEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public Guid LessonPlanId { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
