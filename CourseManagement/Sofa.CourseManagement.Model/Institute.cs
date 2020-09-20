using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class Institute : BaseEntity
    {
        public ICollection<Address> Addresses { get; set; }
        public string Title { get; set; }

        internal Institute()
        {

        }

        public void AssignAddress(IEnumerable<Address> addresses)
        {
            if (Addresses is null)
            {
                Addresses = new List<Address>();
            }

            foreach (var address in addresses)
            {
                var existed = this.Addresses.Contains(address);
                if (!existed)
                {
                    this.Addresses.Add(address);
                }
            }
        }

        public static Institute DefaultFactory(string title, bool isActive)
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
