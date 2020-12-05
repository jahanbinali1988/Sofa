using Sofa.Events.Session;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.SessionConsumer.UpdateSessionIsDeletedStatus
{
    public class UpdateSessionIsDeletedStatusInDataBase : IUnitOfBusiness<UpdateSessionIsDeletedStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSessionIsDeletedStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdateSessionIsDeletedStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.sessionRepository.SafeDelete(message.Id);
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
