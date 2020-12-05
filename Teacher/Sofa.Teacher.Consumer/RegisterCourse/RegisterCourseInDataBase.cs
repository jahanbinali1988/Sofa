using Sofa.Events.Course;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterCourse
{
    public class RegisterCourseInDataBase : IUnitOfBusiness<RegisterCourseEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCourseInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterCourseEvent message)
        {
            try
            {
                if (message.Id != null && message.Id != Guid.Empty)
                {
                    var course = _unitOfWork.courseRepository.Get(message.Id);
             
                    course.AssignDescription(message.Description);
                    course.AssignIsActive(message.IsActive);
                    course.AssignIsDeleted(message.IsDeleted);
                    course.AssignModifiedDate(DateTime.Now);
                    course.IncreaseRowVersion();
                    course.AssignAgeRange(message.AgeRange);
                    course.AssignField(message.FieldId);
                    course.AssignTitle(message.Title);

                    _unitOfWork.courseRepository.Update(course);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                var newCourse = Course.CreateInstance(null, message.Title, message.AgeRange, message.FieldId, message.IsActive, message.Description);

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
