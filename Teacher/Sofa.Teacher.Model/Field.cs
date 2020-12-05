using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.Teacher.Model
{
    public class Field : BaseEntity
    {
        public string Title { get; internal set; }

        public Guid InstituteId { get; internal set; }
        public Institute Institute { get; internal set; }
        public ICollection<Course> Courses { get; internal set; }

        internal Field()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignInstitute(Guid instituteId) { this.InstituteId = instituteId; }
        public void AssignInstitute(Institute institute) { this.InstituteId = institute.Id; this.Institute = institute; }
        public void AssignCourses(IEnumerable<Course> courses)
        {
            if (Courses.Any())
                this.Courses.ToList().AddRange(courses);
            else
                this.Courses = courses.ToArray();
        }

        public static Field CreateInstance(Guid? id, bool isActive, string description)
        {
            var field = new Field();
            field.Id = id.HasValue ? id.Value : Guid.Empty;
            field.AssignCreateDate(DateTime.Now);
            field.AssignFirstRowVersion();
            field.AssignIsActive(isActive);
            field.AssignIsDeleted(false);
            field.AssignDescription(description);

            return field;
        }
        public static Field CreateInstance(Guid? id, string title, Guid instituteId, bool isActive, string description)
        {
            var field = CreateInstance(id, isActive, description);
            field.AssignTitle(title);
            field.AssignInstitute(instituteId);

            return field;
        }
    }
}
