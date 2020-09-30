using Sofa.Events.Lesson;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
                    course.AssignIsActive(message.IsActive);
                    course.AssignModifiedDate(DateTime.Now);
                    course.AssignOrder(message.Order);
                    course.IncreaseRowVersion();
                    course.AssignSyllabus(message.LessonPlanId);
                    course.AssignDescription(message.Description);
                    course.AssignTitle(message.Title);

                    _unitOfWork.courseRepository.Update(course);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newCourse = Course.CreateInstance(null, message.Title, message.Order, message.LessonPlanId, message.Description, message.IsActive);

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
