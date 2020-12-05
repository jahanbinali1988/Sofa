using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;
using System.Linq;

namespace Sofa.CourseManagement.Repository.EF
{
    public class UserRepository : EfRepositoryBase<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User GetByUserName(string userName) => _context.Set<User>().FirstOrDefault(x => x.UserName == userName);
    }
}
