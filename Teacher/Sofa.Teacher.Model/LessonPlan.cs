using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.Teacher.Model
{
    public class LessonPlan : BaseEntity
    {
        public string Title { get; internal set; }

        public ICollection<Course> Courses { get; internal set; }

        internal LessonPlan()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignCourses(IEnumerable<Course> courses)
        {
            if (this.Courses.Any())
                this.Courses.ToList().AddRange(courses);
            else
                this.Courses = courses.ToArray();
        }
        public static LessonPlan CreateInstance(Guid? id, string title, bool isActive, string description)
        {
            return new LessonPlan()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                Title = title,
                IsActive = isActive,
                Description = description,
                CreateDate = DateTime.Now,
                RowVersion = 0,
                IsDeleted = false
            };
        }
    }
}
