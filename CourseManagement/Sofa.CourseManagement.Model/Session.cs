using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.Model
{
    public class Session : BaseEntity
    {
        public string Title { get; set; }
        public Guid LessonPlanId { get; set; }

        public LessonPlan LessonPlan { get; set; }

        public Session DefaultFactory(string title, bool isActive)
        {
            return new Session()
            {
                IsActive = isActive,
                Title = title,
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                RowVersion = 0
            };
        }
    }
}
