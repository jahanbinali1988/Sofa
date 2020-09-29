using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class Institute : BaseEntity
    {
        public string Title { get; private set; }
        public string WebsiteUrl { get; private set; }
        public Address Address { get; private set; }
        public string Code { get; private set; }

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

        public void AssignActivityMode(bool isActive)
        {
            this.IsActive = isActive;
        }

        public static Institute CreateInstance(Guid? id, string title, bool isActive, string code)
        {
            return new Institute()
            {
                CreateDate = DateTime.Now,
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                IsActive = isActive,
                Title = title,
                RowVersion = 0,
                Code = code
            };
        }
    }
}
