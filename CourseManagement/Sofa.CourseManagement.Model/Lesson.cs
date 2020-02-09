using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class Lesson : BaseEntity
    {
        public string Title { get; set; }
        public short Order { get; set; }
        public Guid LessonPlanId { get; set; }

        public ICollection<Post> Posts { get; set; }
        public LessonPlan LessonPlan { get; set; }

        public static Lesson DefaultFactory(string title, short order, Guid lessonPlanId, bool isActive)
        {
            return new Lesson()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Order = order,
                LessonPlanId = lessonPlanId,
                IsActive = isActive
            };
        }
    }
}
