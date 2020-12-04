using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.Teacher.Model
{
    public class Institute : BaseEntity
    {
        public string Title { get; internal set; }
        public ICollection<Field> Fields { get; set; }

        internal Institute()
        {

        }
        public void AssignTitle(string title)
        {
            this.Title = title;
        }
        public void AssignFields(IEnumerable<Field> fields)
        {
            if (this.Fields.Any())
                this.Fields.ToList().AddRange(fields);
            else
                this.Fields = fields.ToArray();
        }

        public static Institute CreateInstance(Guid? id, bool isActive, string description)
        {
            var institute = new Institute()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid()
            };
            institute.AssignCreateDate(DateTime.Now);
            institute.AssignFirstRowVersion();
            institute.AssignIsActive(isActive);
            institute.AssignIsDeleted(false);
            institute.AssignDescription(description);

            return institute;
        }
        public static Institute CreateInstance(Guid? id, string title, bool isActive, string description)
        {
            var institute = CreateInstance(id, isActive, description);
            institute.AssignTitle(title);

            return institute;
        }
    }

}
