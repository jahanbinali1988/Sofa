using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Model
{
    public class Institute : BaseEntity
    {
        public string Title { get; internal set; }
        public string WebsiteUrl { get; internal set; }
        public Address Address { get; internal set; }
        public string Code { get; internal set; }

        public ICollection<Field> Fields { get; set; }

        internal Institute()
        {

        }

        public void AssignAddress(Address address)
        {
            if (Address is null)
            {
                Address = new Address();
            }

            var existed = this.Address.Equals(address);
            if (!existed)
            {
                this.Address = address;
            }
        }
        public void AssignTitle(string title)
        {
            this.Title = title;
        }
        public void AssignCode(string code)
        {
            this.Code = code;
        }
        public void AssignWebsiteUrl(string websiteUrl)
        {
            this.WebsiteUrl = websiteUrl;
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
            var institute = new Institute();
            institute.Id = id.HasValue ? id.Value : Guid.NewGuid();
            institute.AssignCreateDate(DateTime.Now);
            institute.AssignFirstRowVersion();
            institute.AssignIsActive(isActive);
            institute.AssignIsDeleted(false);
            institute.AssignDescription(description);

            return institute;
        }
        public static Institute CreateInstance(Guid? id, string title, string code, string websiteUrl, bool isActive, string description)
        {
            var institute = CreateInstance(id, isActive, description);
            institute.AssignTitle(title);
            institute.AssignCode(code);
            institute.AssignWebsiteUrl(websiteUrl);

            return institute;
        }
    }
}
