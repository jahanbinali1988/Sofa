using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class FieldDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public Guid InstituteId { get; set; }
    }
}
