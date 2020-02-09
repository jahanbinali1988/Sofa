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
                var query = _unitOfWork.userRepository.Query(c=> c.UserName == message.UserName);
                var user = query.SingleOrDefault();

                if (user != null)
                {
                    user.FirstName = message.FirstName;
                    user.LastName = message.LastName;
                    user.PhoneNumber = message.PhoneNumber;
                    user.Email = message.Email;
                    user.CreateDate = DateTime.Now;

                    _unitOfWork.userRepository.Update(user);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newUser = User.DefaultFactory(message.FirstName, message.LastName, message.Email, message.UserName, (LevelEnum)message.Level, 
                    message.PhoneNumber, message.IsActive, Guid.Empty);
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
