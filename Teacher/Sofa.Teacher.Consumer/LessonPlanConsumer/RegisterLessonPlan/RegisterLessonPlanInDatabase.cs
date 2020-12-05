using Sofa.Events.LessonPlan;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.LessonPlanConsumer.RegisterLessonPlan
{
    public class RegisterLessonPlanInDatabase : IUnitOfBusiness<RegisterLessonPlanEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterLessonPlanInDatabase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterLessonPlanEvent message)
        {
            try
            {
                if (message.Id != null && message.Id != Guid.Empty)
                {
                    LessonPlan lessonPlan = _unitOfWork.lessonPlanRepository.Get(message.Id);

                    lessonPlan.AssignDescription(message.Description);
                    lessonPlan.AssignIsActive(message.IsActive);
                    lessonPlan.AssignIsDeleted(message.IsDeleted);
                    lessonPlan.AssignModifiedDate(DateTime.Now);
                    lessonPlan.IncreaseRowVersion();
                    lessonPlan.AssignSession(message.SessionId);
                    lessonPlan.AssignLevel(message.Level);

                    _unitOfWork.lessonPlanRepository.Update(lessonPlan);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                LessonPlan newLessonPlan = LessonPlan.CreateInstance(null, message.Level, message.SessionId, message.IsActive, message.Description);

                await _unitOfWork.lessonPlanRepository.AddAsync(newLessonPlan);
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
