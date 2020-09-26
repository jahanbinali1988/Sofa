using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class InstituteDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsActive { get; set; }

        public AddressDto Address { get; set; }
    }
}
