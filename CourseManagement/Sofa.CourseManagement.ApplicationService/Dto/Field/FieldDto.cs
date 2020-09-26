using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class FieldDto
    {
        public Guid Id { get; set; }
        public string Title { get; private set; }
        public bool IsActive { get; set; }

        public Guid InstituteId { get; set; }
    }
}
