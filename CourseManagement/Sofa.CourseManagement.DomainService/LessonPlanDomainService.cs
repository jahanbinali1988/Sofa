using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.CourseManagement.Repository;

namespace Sofa.CourseManagement.DomainService
{
    public class LessonPlanDomainService : ILessonPlanDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LessonPlanDomainService(IUnitOfWork uniteOfWork)
        {
            _unitOfWork = uniteOfWork;
        }

        public void CanAdd(string title)
        {
            var isDuplicatedTitle = _unitOfWork.lessonPlanRepository.Any(c => c.Title.Equals(title));
            if (isDuplicatedTitle)
            {
                throw new BusinessException("نام وارد شده تکراری است");
            }
        }
    }
}
