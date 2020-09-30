using Sofa.CourseManagement.Repository;
using Sofa.SharedKernel.BaseClasses.Exceptions;

namespace Sofa.CourseManagement.DomainService
{
    public class CourseDomainService : ICourseDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseDomainService(IUnitOfWork uniteOfWork)
        {
            _unitOfWork = uniteOfWork;
        }

        public void CanAdd(string title)
        {
            var isDuplicatedTitle = _unitOfWork.courseRepository.Any(c => c.Title.Equals(title));
            if (isDuplicatedTitle)
            {
                throw new BusinessException("نام وارد شده تکراری است");
            }
        }
    }
}
