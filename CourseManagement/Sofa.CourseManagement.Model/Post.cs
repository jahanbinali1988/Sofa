using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.Model
{
    public class Post : BaseEntity
    {
        public string Title { get; private set; }
        public short Order { get; private set; }
        public PostTypeEnum PostType { get; private set; }

        public Guid LessonPlanId { get; set; }
        public LessonPlan LessonPlan { get; set; }

        public static Post CreateInstance(string title, short order, PostTypeEnum postType, Guid LessonPlanId, bool isActive)
        {
            return new Post()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Order = order,
                PostType = postType,
                LessonPlanId = LessonPlanId,
                IsActive = isActive,
                RowVersion = 0
            };
        }
    }
}
