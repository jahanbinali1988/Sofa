using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.SharedKernel.BaseClasses
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey> where TKey : struct
    {
        [Key]
        public virtual TKey Id { get; set; }
        public string Description { get; protected set; }
        public int RowVersion { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime ModifyDate { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public bool IsActive { get; protected set; }

        public void Dispose()
        {
            this.Dispose();
        }

        public void AssignFirstRowVersion()
        {
            RowVersion = 0;
        }
        public void IncreaseRowVersion()
        {
            RowVersion += 1;
        }
        public void AssignDescription(string description)
        {
            this.Description = description;
        }
        public void AssignIsActive(bool isActive)
        {
            this.IsActive = isActive;
        }
        public void AssignIsDeleted(bool isDeleted)
        {
            this.IsDeleted = isDeleted;
        }
        public void AssignCreateDate(DateTime createDate)
        {
            this.CreateDate = createDate;
        }
        public void AssignModifiedDate(DateTime modifiedDate)
        {
            this.ModifyDate = modifiedDate;
        }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {

    }
}
