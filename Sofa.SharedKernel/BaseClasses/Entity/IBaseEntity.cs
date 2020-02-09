using System;

namespace Sofa.SharedKernel.BaseClasses
{
    public interface IBaseEntity<TKey> : IDisposable where TKey : struct
    {
        TKey Id { get; set; }
    }

    public interface IBaseEntity : IBaseEntity<Guid>
    {
    }
}
