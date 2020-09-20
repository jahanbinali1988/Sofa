using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.Model
{
    public class Field : BaseEntity
    {
        public string Title { get; set; }

        public Field DefaultFactory(string title, bool isActive)
        {
            return new Field()
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
