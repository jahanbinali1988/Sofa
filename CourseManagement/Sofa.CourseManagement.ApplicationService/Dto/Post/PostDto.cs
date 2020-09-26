using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public PostTypeEnum PostType { get; set; }
        public string PostTypeCaption { get; set; }
        public bool IsActive { get; set; }

        public Guid LessonPlanId { get; set; }
    }
}
