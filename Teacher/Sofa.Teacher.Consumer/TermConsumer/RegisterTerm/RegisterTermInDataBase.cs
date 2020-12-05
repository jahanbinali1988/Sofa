using Sofa.Events.Term;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.TermConsumer.RegisterTerm
{
    public class RegisterTermInDataBase : IUnitOfBusiness<RegisterTermEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterTermInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterTermEvent message)
        {
            try
            {
                if (message.Id != null && message.Id != Guid.Empty)
                {
                    Term term = _unitOfWork.termRepository.Get(message.Id);

                    term.AssignDescription(message.Description);
                    term.AssignIsActive(message.IsActive);
                    term.AssignIsDeleted(message.IsDeleted);
                    term.AssignModifiedDate(DateTime.Now);
                    term.IncreaseRowVersion();
                    term.AssignTitle(message.Title);
                    term.AssignCourse(message.CourseId);
                    
                    _unitOfWork.termRepository.Update(term);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                Term newTerm = Term.CreateInstance(null, message.Title, message.CourseId, message.IsActive, message.Description);

                await _unitOfWork.termRepository.AddAsync(newTerm);
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
