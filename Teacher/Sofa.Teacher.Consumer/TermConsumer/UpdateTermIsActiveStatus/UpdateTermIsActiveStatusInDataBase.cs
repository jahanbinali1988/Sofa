using Sofa.Events.Term;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.TermConsumer.UpdateTermIsActiveStatus
{
    public class UpdateTermIsActiveStatusInDataBase : IUnitOfBusiness<UpdateTermIsActiveStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTermIsActiveStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdateTermIsActiveStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.termRepository.ChangeActiveStatus(message.Id);
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
