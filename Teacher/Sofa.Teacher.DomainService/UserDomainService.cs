using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System.Threading.Tasks;

namespace Sofa.Teacher.DomainService
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserDomainService(IUnitOfWork uniteOfWork)
        {
            this._unitOfWork = uniteOfWork;
        }

        public async Task CanAdd(User user)
        {
            var usernameExited = await _unitOfWork.userRepository.AnyAsync(c => c.UserName.Equals(user.UserName));

            if (usernameExited)
                throw new BusinessException("نام کاربری وارد شده تکراری است");
        }

        public async Task<bool> Existance(string phoneNumber)
        {
            bool flag = true;

            var usernameExited = await _unitOfWork.userRepository.AnyAsync(c => c.PhoneNumber.Equals(phoneNumber));
            if (!usernameExited)
                flag = false;

            return flag;
        }
    }
}
