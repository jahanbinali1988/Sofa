using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Model
{
    public class Term : BaseEntity
    {
        public string Title { get; internal set; }

        public Guid CourseId { get; internal set; }
        public Course Course { get; internal set; }
        public ICollection<Session> Sessions { get; internal set; }

        internal Term()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignCourse(Guid courseId) { this.CourseId = courseId; }
        public void AssignCourse(Course course) { this.CourseId = course.Id; this.Course = course; }
        public void AssignSessions(IEnumerable<Session> sessions) 
        {
            if (this.Sessions.Any())
                this.Sessions.ToList().AddRange(sessions);
            else
                this.Sessions = sessions.ToArray();
        }

        public static Term CreateInstance(Guid? id, bool isActive, string description)
        {
            var term = new Term();
            term.Id = id.HasValue ? id.Value : Guid.Empty;
            term.AssignCreateDate(DateTime.Now);
            term.AssignFirstRowVersion();
            term.AssignIsActive(isActive);
            term.AssignIsDeleted(false);
            term.AssignDescription(description);

            return term;
        }
        public static Term CreateInstance(Guid? id, string title, bool isActive, Guid courseId, string description)
        {
            var term = CreateInstance(id, isActive, description);
            term.AssignTitle(title);
            term.AssignCourse(courseId);

            return term;
        }
    }
}
