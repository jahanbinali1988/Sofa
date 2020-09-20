using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.Model
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string AgeRange { get; set; }

        public Course DefaultFactory(string title, string ageRange, bool isActive)
        {
            return new Course()
            {
                Id = Guid.NewGuid(),
                Title = title,
                CreateDate = DateTime.Now,
                AgeRange = ageRange,
                IsActive = isActive,
                RowVersion = 0
            };
        }
    }
}
