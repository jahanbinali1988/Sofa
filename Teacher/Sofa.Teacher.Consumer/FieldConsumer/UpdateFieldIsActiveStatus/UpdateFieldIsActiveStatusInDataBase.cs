using Sofa.Events.Field;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.FieldConsumer.UpdateFieldIsActiveStatus
{
    public class UpdateFieldIsActiveStatusInDataBase : IUnitOfBusiness<UpdateFieldIsActiveStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFieldIsActiveStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdateFieldIsActiveStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.fieldRepository.ChangeActiveStatus(message.Id);
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
