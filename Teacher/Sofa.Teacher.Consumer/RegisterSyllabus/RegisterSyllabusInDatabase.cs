using Sofa.Events.LessonPlan;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterSyllabus
{
    class RegisterSyllabusInDatabase : IUnitOfBusiness<RegisterLessonPlanEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterSyllabusInDatabase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterLessonPlanEvent message)
        {
            try
            {
                var syllabus = _unitOfWork.syllabusRepository.Query(c => c.Id == message.Id).SingleOrDefault();

                if (syllabus != null)
                {
                    syllabus.AssignModifiedDate(DateTime.Now);
                    syllabus.IncreaseRowVersion();
                    syllabus.AssignTitle(message.Title);
                    syllabus.AssignDescription(message.Description);
                    syllabus.AssignIsActive(message.IsActive);

                    _unitOfWork.syllabusRepository.Update(syllabus);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newSyllabus = Syllabus.CreateInstance(null, message.Title, message.IsActive, message.Description);

                await _unitOfWork.syllabusRepository.AddAsync(newSyllabus);
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
