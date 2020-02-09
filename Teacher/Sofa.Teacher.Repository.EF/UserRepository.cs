using Sofa.Teacher.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
{
    public class UserRepository : EfRepositoryBase<User, Guid>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
