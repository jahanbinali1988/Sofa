using System;
using System.Linq;
using Sofa.Identity.EntityFramework.Context;
using Sofa.Identity.EntityFramework.Repository;
using Sofa.Identity.Model;
using Sofa.Identity.Repository;

namespace Sofa.Identity.repository.EF
{
    public class EfUserRepository : EfRepositoryBase<User, Guid>, IEfUserRepository
    {
        public EfUserRepository(SofaIdentityDbContext context) : base(context)
        {
        }

        public User GetByUserName(string userName) => _context.Set<User>().FirstOrDefault(x => x.UserName == userName);
    }
}
