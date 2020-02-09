using System;

namespace Sofa.Events.Post
{
    public class RegisterPostEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public short PostType { get; set; }
        public Guid LessonId { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
