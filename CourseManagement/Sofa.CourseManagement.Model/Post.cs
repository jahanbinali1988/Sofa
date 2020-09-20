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

        public Guid LessonPlanId { get; set; }
        public LessonPlan LessonPlan { get; set; }

        public static Post DefaultFactory(string title, short order, PostTypeEnum postType, Guid LessonPlanId, bool isActive)
        {
            return new Post()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Order = order,
                PostType = postType,
                LessonPlanId = LessonPlanId,
                IsActive = isActive
            };
        }
    }
}
