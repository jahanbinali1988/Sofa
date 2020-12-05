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
                    user.AssignFirstName(message.FirstName);
                    user.AssignLastName(message.LastName);
                    user.ChangePassword(message.PasswordHash);
                    user.AssignPhoneNumber(message.PhoneNumber);
                    user.AssignEmail(message.Email);
                    user.AssignModifiedDate(DateTime.Now);
                    user.AssignRole((UserRoleEnum)message.Role);

                    _unitOfWork.userRepository.Update(user);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newUser = User.CreateInstance(null, message.FirstName, message.LastName, message.PasswordHash, message.Email, message.UserName,
                    UserRoleEnum.Student, message.PhoneNumber, true, null, null, message.Description, (LevelEnum)message.Level);

                await _unitOfWork.userRepository.AddAsync(newUser);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return false;
            }
        }
    }
}
