using System;

namespace Sofa.Events.Session
{
    public class RegisterSessionEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid TermId { get; set; }
        public Guid LessonPlanId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
