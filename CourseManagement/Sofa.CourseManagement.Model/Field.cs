using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class Field : BaseEntity
    {
        public string Title { get; private set; }

        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }

        public ICollection<Course> Courses { get; set; }

        public static Field CreateInstance(string title, bool isActive, Guid instituteId)
        {
            return new Field()
            {
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                IsActive = isActive,
                Title = title,
                RowVersion = 0,
                InstituteId = instituteId
            };
        }
    }
}
