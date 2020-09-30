using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public string Content { get; set; }
        public ContentTypeEnum ContentType { get; set; }
        public string PostTypeCaption { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid LessonPlanId { get; set; }
    }
}
