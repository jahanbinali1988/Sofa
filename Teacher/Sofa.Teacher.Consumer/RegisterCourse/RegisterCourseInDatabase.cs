using Sofa.Events.Lesson;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterCourse
{
    public class RegisterCourseInDatabase : IUnitOfBusiness<RegisterLessonEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterCourseInDatabase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterLessonEvent message)
        {
            try
            {
                var course = _unitOfWork.courseRepository.Query(c => c.Id == message.Id).SingleOrDefault();
                if (course != null)
                {
                    course.IsActive = message.IsActive;
                    course.ModifyDate = DateTime.Now;
                    course.Order = message.Order;
                    course.RowVersion = ++course.RowVersion;
                    course.SyllabusId = message.LessonPlanId;
                    course.Description = message.Description;
                    course.Title = message.Title;

                    _unitOfWork.courseRepository.Update(course);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newCourse = Course.DefaultFactory(message.Title, message.Order, message.LessonPlanId, message.Description, message.IsActive);

                await _unitOfWork.courseRepository.AddAsync(newCourse);
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
