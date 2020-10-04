using System;

namespace Sofa.Events.Field
{
    public class RegisterFieldEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid InstituteId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
