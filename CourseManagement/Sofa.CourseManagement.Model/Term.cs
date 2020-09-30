using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static Term CreateInstance(Guid? id, string title, bool isActive, Guid courseId, string description)
        {
            return new Term()
            {
                CreateDate = DateTime.Now,
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                IsActive = isActive,
                RowVersion = 0,
                Title = title,
                CourseId = courseId,
                Description = description,
                IsDeleted = false
            };
        }
    }
}
