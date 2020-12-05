using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.User;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Consumer.RegisterUser
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
                    (UserRoleEnum)message.Role, message.PhoneNumber, message.IsActive, message.Description, (LevelEnum)message.Level);

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
