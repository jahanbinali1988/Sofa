using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using System;
using System.Linq;

namespace Sofa.CourseManagement.Repository.EF
{
    public class UserRepository : EfRepositoryBase<User, Guid>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetByUserName(string userName) => _context.Set<User>().FirstOrDefault(x => x.UserName == userName);
    }
}
