using Sofa.Events.Post;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.PostConsumer.UpdatePostIsActiveStatus
{
    public class UpdatePostIsActiveStatusInDataBase : IUnitOfBusiness<UpdatePostIsActiveStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePostIsActiveStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdatePostIsActiveStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.postRepository.ChangeActiveStatus(message.Id);
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
