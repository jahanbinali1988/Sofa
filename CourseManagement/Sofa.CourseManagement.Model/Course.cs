using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Model
{
    public class Course : BaseEntity
    {
        public string Title { get; internal set; }
        public AgeRangeEnum AgeRange { get; internal set; }

        public Guid FieldId { get; internal set; }
        public Field Field { get; internal set; }
        public ICollection<Term> Terms { get; internal set; }

        internal Course()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignAgeRange(AgeRangeEnum ageRange) { this.AgeRange = ageRange; }
        public void AssignField(Guid fieldId) { this.FieldId = fieldId; }
        public void AssignField(Field field) { this.Field = field; this.FieldId = field.Id; }
        public void AssignTerms(IEnumerable<Term> terms) 
        {
            if (Terms.Any())
                this.Terms.ToList().AddRange(terms);
            else
                this.Terms = terms.ToArray();
        }
        public static Course CreateInstance(Guid? id, string title, AgeRangeEnum ageRange, bool isActive, Guid fieldId)
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
