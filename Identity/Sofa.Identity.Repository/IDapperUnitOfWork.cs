using System;

namespace Sofa.Identity.Repository
{
    public interface IDapperUnitOfWork : IDisposable
    {
        IDapperUserRepository Users { get; }

        void Save();
    }
}
