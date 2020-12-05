using Sofa.Events.Institute;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.InstituteConsumer.UpdateInstituteIsDeletedStatus
{
    public class UpdateInstituteIsDeletedStatusInDataBase : IUnitOfBusiness<UpdateInstituteIsDeletedStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateInstituteIsDeletedStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdateInstituteIsDeletedStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.instituteRepository.SafeDelete(message.Id);
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
