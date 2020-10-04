using System;

namespace Sofa.Events.Post
{
    public class RegisterPostEvent
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public short Order { get; set; }
        public String Content { get; set; }
        public short ContentType { get; set; }
        public Guid LessonPlanId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
