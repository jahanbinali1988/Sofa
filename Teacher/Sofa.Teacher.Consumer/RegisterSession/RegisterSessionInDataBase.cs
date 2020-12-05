using Sofa.Events.Session;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterSession
{
    public class RegisterSessionInDataBase : IUnitOfBusiness<RegisterSessionEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterSessionInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterSessionEvent message)
        {
            try
            {
                if (message.Id != null && message.Id != Guid.Empty)
                {
                    Session session = _unitOfWork.sessionRepository.Get(message.Id);

                    session.AssignDescription(message.Description);
                    session.AssignIsActive(message.IsActive);
                    session.AssignIsDeleted(message.IsDeleted);
                    session.AssignModifiedDate(DateTime.Now);
                    session.IncreaseRowVersion();
                    session.AssignTitle(message.Title);
                    session.AssignLessonPlan(message.LessonPlanId);
                    session.AssignTerm(message.TermId);
                    
                    _unitOfWork.sessionRepository.Update(session);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                Session newSession = Session.CreateInstance(null, message.Title, message.LessonPlanId, message.TermId, message.IsActive, message.Description);

                await _unitOfWork.sessionRepository.AddAsync(newSession);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                return false;
            }
        }
    }
}
