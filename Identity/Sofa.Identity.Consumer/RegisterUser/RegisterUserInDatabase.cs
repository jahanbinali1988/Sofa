using Sofa.Events.User;
using Sofa.Identity.Model;
using Sofa.Identity.Repository;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;
using System.Threading.Tasks;

namespace Sofa.Identiity.Consumer.RegisterUser
{
    public class RegisterUserInDatabase : IUnitOfBusiness<RegisteredUserEvent, bool>
    {
        private readonly IEfUnitOfWork _unitOfWork;

        public RegisterUserInDatabase(IEfUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisteredUserEvent message)
        {
            try
            {
                var user = _unitOfWork.userRepository.GetByUserName(message.UserName);
                if (user != null)
                {
                    user.FirstName = message.FirstName;
                    user.LastName = message.LastName;
                    user.PasswordHash = message.PasswordHash;
                    user.PhoneNumber = message.PhoneNumber;
                    user.Email = message.Email;
                    user.CreateDate = DateTime.Now;
                    user.Role = (UserRoleEnum)message.Role;

                    _unitOfWork.userRepository.Update(user);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                
                var newUser = User.DefaultFactory(message.FirstName, message.LastName, message.PasswordHash, message.Email, message.UserName,
                    UserRoleEnum.Student, message.PhoneNumber, true, null, null);

                newUser.PasswordHash = message.PasswordHash;
                newUser.Description = message.Description;

                await _unitOfWork.userRepository.AddAsync(newUser);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                return false;
            }
        }
    }
}
