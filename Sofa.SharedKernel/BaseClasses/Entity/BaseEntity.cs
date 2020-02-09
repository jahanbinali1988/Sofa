using System;

namespace Sofa.SharedKernel.BaseClasses
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey> where TKey : struct
    {
        public virtual TKey Id { get; set; }
        public string Description { get; set; }
        public int RowVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {

    }
}
