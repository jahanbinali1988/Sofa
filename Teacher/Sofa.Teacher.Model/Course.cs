using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.Teacher.Model
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public short Order { get; set; }
        public Guid SyllabusId { get; set; }

        public ICollection<Post> Posts { get; set; }
        public Syllabus Syllabus { get; set; }
        public static Course DefaultFactory(string title, short order, Guid syllabusId, string description, bool isActive)
        {
            return new Course()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Order = order,
                SyllabusId = syllabusId,
                CreateDate = DateTime.Now,
                Description = description,
                IsActive = isActive,
                RowVersion = 1
            };
        }
    }
}
