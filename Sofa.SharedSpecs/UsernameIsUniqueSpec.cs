using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using System;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public class UsernameIsUniqueSpec : Specification<User>
    {
        private readonly IUserRepository userRepository;

        public UsernameIsUniqueSpec(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return x => userRepository.GetByUserName(x.UserName) == null;
        }
    }
}
