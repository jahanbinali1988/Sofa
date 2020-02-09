using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.Teacher.Model
{
    public class Syllabus : BaseEntity
    {
        public string Title { get; set; }

        public ICollection<Course> Course { get; set; }

        public static Syllabus DefaultFactory(string title, bool isActive, string description)
        {
            return new Syllabus()
            {
                Id = Guid.NewGuid(),
                Title = title,
                IsActive = isActive,
                Description = description,
                CreateDate = DateTime.Now,
                RowVersion = 1
            };
        }
    }
}
