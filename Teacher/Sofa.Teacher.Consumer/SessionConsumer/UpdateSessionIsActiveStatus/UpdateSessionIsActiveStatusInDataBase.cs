using Sofa.Events.Session;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.SessionConsumer.UpdateSessionIsActiveStatus
{
    public class UpdateSessionIsActiveStatusInDataBase : IUnitOfBusiness<UpdateSessionIsActiveStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSessionIsActiveStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdateSessionIsActiveStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.sessionRepository.ChangeActiveStatus(message.Id);
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
