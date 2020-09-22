using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class Institute : BaseEntity
    {
        public string Title { get; private set; }

        public Address Address { get; private set; }

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

        public void AssignActivityMode(bool isActive)
        {
            this.IsActive = isActive;
        }

        public static Institute CreateInstance(string title, bool isActive)
        {
            return new Institute()
            {
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                IsActive = isActive,
                Title = title,
                RowVersion = 0
            };
        }
    }
}
