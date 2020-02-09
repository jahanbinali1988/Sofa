using System;

namespace Sofa.Events.LessonPlan
{
    public class RegisterLessonPlanEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Level { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
