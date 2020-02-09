using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Sofa.Identity.Repository
{
    public interface IEfUnitOfWork : IDisposable
    {
        IEfUserRepository userRepository { get; }

        void Commit();

        Task CommitAsync();
    }
}
