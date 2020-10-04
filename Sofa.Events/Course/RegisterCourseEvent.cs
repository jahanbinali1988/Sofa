using System;

namespace Sofa.Events.Course
{
    public class RegisterCourseEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short AgeRange { get; set; }
        public Guid FieldId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
