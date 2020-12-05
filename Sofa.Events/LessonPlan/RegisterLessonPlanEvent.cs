using System;

namespace Sofa.Events.LessonPlan
{
    public class RegisterLessonPlanEvent
    {
        public Guid Id { get; set; }
        public short Level { get; set; }
        public Guid SessionId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
