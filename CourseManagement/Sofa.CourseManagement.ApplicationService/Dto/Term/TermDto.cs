using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class TermDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public Guid CourseId { get; set; }
    }
}
