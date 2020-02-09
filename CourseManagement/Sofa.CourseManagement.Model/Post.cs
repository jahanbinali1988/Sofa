using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.Model
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public short Order { get; set; }
        public PostTypeEnum PostType { get; set; }
        public Guid LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public static Post DefaultFactory(string title, short order, PostTypeEnum postType, Guid LessonId, bool isActive)
        {
            return new Post()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Order = order,
                PostType = postType,
                LessonId = LessonId,
                IsActive = isActive
            };
        }
    }
}
