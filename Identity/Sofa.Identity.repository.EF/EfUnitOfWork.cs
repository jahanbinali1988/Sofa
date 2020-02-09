using Sofa.Identity.EntityFramework.Context;
using Sofa.Identity.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Identity.repository.EF
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly SofaIdentityDbContext _context;

        public IEfUserRepository userRepository => new EfUserRepository(_context);

        public EfUnitOfWork(SofaIdentityDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}
