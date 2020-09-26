using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AgeRange { get; set; }
        public bool IsActive { get; set; }

        public Guid FieldId { get; set; }
    }
}
