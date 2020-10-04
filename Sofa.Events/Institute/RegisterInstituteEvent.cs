using System;

namespace Sofa.Events.Institute
{
    public class RegisterInstituteEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string WebsiteUrl { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
