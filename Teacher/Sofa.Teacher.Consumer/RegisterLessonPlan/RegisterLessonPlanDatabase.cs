using Sofa.Events.LessonPlan;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterLessonPlan
{
    class RegisterLessonPlanInDatabase : IUnitOfBusiness<RegisterLessonPlanEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterLessonPlanInDatabase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterLessonPlanEvent message)
        {
            try
            {
                var lessonPlan = _unitOfWork.lessonPlanRepository.Query(c => c.Id == message.Id).SingleOrDefault();

                if (lessonPlan != null)
                {
                    lessonPlan.AssignModifiedDate(DateTime.Now);
                    lessonPlan.IncreaseRowVersion();
                    lessonPlan.AssignDescription(message.Description);
                    lessonPlan.AssignIsActive(message.IsActive);

                    _unitOfWork.lessonPlanRepository.Update(lessonPlan);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newLessonPlan = LessonPlan.CreateInstance(null, string.Empty, message.IsActive, message.Description);

                await _unitOfWork.lessonPlanRepository.AddAsync(newLessonPlan);
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
