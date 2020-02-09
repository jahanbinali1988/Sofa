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
                var query = _unitOfWork.syllabusRepository.Query(c => c.Id == message.Id);
                var syllabus = query.SingleOrDefault();

                if (syllabus != null)
                {
                    syllabus.IsActive = message.IsActive;
                    syllabus.ModifyDate = DateTime.Now;
                    syllabus.RowVersion = ++syllabus.RowVersion;
                    syllabus.Title = message.Title;
                    syllabus.Description = message.Description;

                    _unitOfWork.syllabusRepository.Update(syllabus);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newSyllabus = Syllabus.DefaultFactory(message.Title, message.IsActive, message.Description);

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
