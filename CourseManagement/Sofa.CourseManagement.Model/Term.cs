using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class Term : BaseEntity
    {
        public string Title { get; private set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Session> Sessions { get; set; }

        public static Term CreateInstance(string title, bool isActive, Guid courseId)
        {
            return new Term()
            {
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                IsActive = isActive,
                RowVersion = 0,
                Title = title,
                CourseId = courseId
            };
        }
    }
}
