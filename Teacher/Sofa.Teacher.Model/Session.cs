using Sofa.SharedKernel.BaseClasses;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sofa.Teacher.Model
{
    public class Session : BaseEntity
    {
        public string Title { get; internal set; }

        public Guid TermId { get; internal set; }
        public Term Term { get; internal set; }
        public Guid LessonPlanId { get; internal set; }
        [NotMapped]
        public LessonPlan LessonPlan { get; internal set; }

        internal Session()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignTerm(Guid termId) { this.TermId = termId; }
        public void AssignTerm(Term term) { this.TermId = term.Id; this.Term = term; }
        public void AssignLessonPlan(Guid lessonPlanId) { this.LessonPlanId = lessonPlanId; }
        public void AssignLessonPlan(LessonPlan lessonPlan) { this.LessonPlanId = lessonPlan.Id; this.LessonPlan = lessonPlan; }

        public static Session CreateInstance(Guid? id, bool isActive, string description)
        {
            var session = new Session();
            session.Id = id.HasValue ? id.Value : Guid.Empty;
            session.AssignCreateDate(DateTime.Now);
            session.AssignFirstRowVersion();
            session.AssignIsActive(isActive);
            session.AssignIsDeleted(false);
            session.AssignDescription(description);

            return session;
        }
        public static Session CreateInstance(Guid? id, string title, Guid lessonPlanId, Guid termId, bool isActive, string description)
        {
            var session = CreateInstance(id, isActive, description);
            session.AssignTitle(title);
            session.AssignLessonPlan(lessonPlanId);
            session.AssignTerm(termId);

            return session;
        }
    }
}
