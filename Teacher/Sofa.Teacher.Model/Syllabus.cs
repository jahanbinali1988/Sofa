using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.Teacher.Model
{
    public class Syllabus : BaseEntity
    {
        public string Title { get; internal set; }

        public ICollection<Course> Courses { get; internal set; }

        internal Syllabus()
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
        public static Syllabus CreateInstance(Guid? id, string title, bool isActive, string description)
        {
            return new Syllabus()
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
