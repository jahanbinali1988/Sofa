using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.Model
{
    public class Session : BaseEntity
    {
        public string Title { get; private set; }

        public Guid TermId { get; set; }
        public Term Term { get; set; }
        public Guid LessonPlanId { get; set; }
        public LessonPlan LessonPlan { get; set; }

        public Session CreateInstance(string title, bool isActive)
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
