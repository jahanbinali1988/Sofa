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
        public static Institute CreateInstance(Guid? id, string title, bool isActive, string code, string websiteUrl, string description)
        {
            return new Institute()
            {
                CreateDate = DateTime.Now,
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                IsActive = isActive,
                Title = title,
                RowVersion = 0,
                Code = code,
                WebsiteUrl = websiteUrl,
                Description = description
            };
        }
    }
}
