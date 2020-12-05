using Sofa.Events.User;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterUser
{
    public class RegisterUserInDatabase : IUnitOfBusiness<RegisteredUserEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserInDatabase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisteredUserEvent message)
        {
            try
            {
                var user = _unitOfWork.userRepository.Query(c => c.UserName == message.UserName).SingleOrDefault();

                if (user != null)
                {
                    user.AssignDescription(message.Description);
                    user.AssignEmail(message.Email);
                    user.AssignFirstName(message.FirstName);
                    user.AssignIsActive(message.IsActive);
                    user.AssignIsDeleted(message.IsDeleted);
                    user.AssignLevel((LevelEnum)message.Level);
                    user.AssignModifiedDate(DateTime.Now);
                    user.AssignPhoneNumber(message.PhoneNumber);
                    user.AssignUserName(message.UserName);
                    _unitOfWork.userRepository.Update(user);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newUser = User.CreateInstance(null, message.FirstName, message.LastName, message.Email, message.UserName, message.Level,
                    message.PhoneNumber, Guid.Empty, message.IsActive, message.Description);

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
