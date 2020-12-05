using Sofa.Events.User;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.UserConsumer.UpdateUserIsDeletedStatus
{
    public class UpdateUserIsDeletedStatusInDataBase : IUnitOfBusiness<UpdateUserIsDeletedStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserIsDeletedStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdateUserIsDeletedStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.userRepository.SafeDelete(message.Id);
                    await _unitOfWork.CommitAsync();
                }
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
