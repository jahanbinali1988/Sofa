using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedSpecs;

namespace Sofa.CourseManagement.DomainService
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserDomainService(IUnitOfWork uniteOfWork)
        {
            _unitOfWork = uniteOfWork;
        }

        public void CanAdd(User user)
        {
            UsernameIsUniqueSpec usernameExistedSpec = new UsernameIsUniqueSpec(_unitOfWork.userRepository);

            if (!usernameExistedSpec.IsSatisfiedBy(user))
                throw new BusinessException("نام وارد شده تکراری است");
        }
    }
}
