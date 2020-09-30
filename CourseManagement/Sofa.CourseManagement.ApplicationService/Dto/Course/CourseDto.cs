using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public AgeRangeEnum AgeRange { get; set; }
        public bool IsActive { get; set; }

        public Guid FieldId { get; set; }
    }
}
