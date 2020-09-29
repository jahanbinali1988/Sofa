using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class Course : BaseEntity
    {
        public string Title { get; private set; }
        public string AgeRange { get; private set; }
        
        public Guid FieldId { get; set; }
        public Field Field { get; set; }
        public ICollection<Term> Terms { get; set; }

        public static Course CreateInstance(Guid? id, string title, string ageRange, bool isActive, Guid fieldId)
        {
            return new Course()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                Title = title,
                CreateDate = DateTime.Now,
                AgeRange = ageRange,
                IsActive = isActive,
                RowVersion = 0,
                FieldId = fieldId
            };
        }
    }
}
