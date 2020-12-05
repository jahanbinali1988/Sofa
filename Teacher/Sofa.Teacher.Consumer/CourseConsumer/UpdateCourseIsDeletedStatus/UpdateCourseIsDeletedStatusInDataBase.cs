using Sofa.Events.Course;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.CourseConsumer.UpdateCourseIsDeletedStatus
{
    public class UpdateCourseIsDeletedStatusInDataBase : IUnitOfBusiness<UpdateCourseIsDeletedStatusEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCourseIsDeletedStatusInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(UpdateCourseIsDeletedStatusEvent message)
        {
            try
            {
                if (message.Id != Guid.Empty)
                {
                    _unitOfWork.courseRepository.SafeDelete(message.Id);
                    await _unitOfWork.CommitAsync();
                }
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
