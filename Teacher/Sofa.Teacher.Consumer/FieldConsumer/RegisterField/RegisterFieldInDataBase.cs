using Sofa.Events.Field;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.FieldConsumer.RegisterField
{
    public class RegisterFieldInDataBase : IUnitOfBusiness<RegisterFieldEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterFieldInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterFieldEvent message)
        {
            try
            {
                Field field = _unitOfWork.fieldRepository.Get(message.Id);
                if (field != null)
                {
                    field.AssignDescription(message.Description);
                    field.AssignIsActive(message.IsActive);
                    field.AssignIsDeleted(message.IsDeleted);
                    field.AssignModifiedDate(DateTime.Now);
                    field.IncreaseRowVersion();
                    field.AssignTitle(message.Title);

                    _unitOfWork.fieldRepository.Update(field);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                var newField = Field.CreateInstance(null, message.Title, message.InstituteId, message.IsActive, message.Description);

                await _unitOfWork.fieldRepository.AddAsync(newField);
                await _unitOfWork.CommitAsync();
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
