using Sofa.SharedKernel.BaseClasses;
using System;
using System.ComponentModel;

namespace Sofa.CourseManagement.Model
{
    public class Session : BaseEntity
    {
        public string Title { get; internal set; }

        public Guid TermId { get; internal set; }
        public Term Term { get; internal set; }
        public Guid LessonPlanId { get; internal set; }
        public LessonPlan LessonPlan { get; internal set; }

        internal Session()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignTerm(Guid termId) { this.TermId = termId; }
        public void AssignTerm(Term term) { this.TermId = term.Id; this.Term = term; }
        public void AssignLessonPlan(Guid lessonPlanId) { this.LessonPlanId = lessonPlanId; }
        public void AssignLessonPlan(LessonPlan lessonPlan) { this.LessonPlanId = lessonPlan.Id; this.LessonPlan = lessonPlan; }
        public static Session CreateInstance(Guid? id, string title, bool isActive, Guid lessonPlanId, Guid termId, string description)
        {
            return new Session()
            {
                IsActive = isActive,
                Title = title,
                CreateDate = DateTime.Now,
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                RowVersion = 0,
                LessonPlanId = lessonPlanId,
                TermId = termId,
                Description = description,
                IsDeleted = false
            };
        }
    }
}
