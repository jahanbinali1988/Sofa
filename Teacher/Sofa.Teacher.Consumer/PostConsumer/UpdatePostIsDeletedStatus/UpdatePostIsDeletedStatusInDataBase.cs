using Sofa.Events.Post;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.PostConsumer.UpdatePostIsDeletedStatus
{
    public class UpdatePostIsDeletedStatusInDataBase : IUnitOfBusiness<UpdatePostIsDeletedStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePostIsDeletedStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdatePostIsDeletedStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.postRepository.SafeDelete(message.Id);
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
