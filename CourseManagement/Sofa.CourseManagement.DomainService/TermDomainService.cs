using Sofa.CourseManagement.Repository;
using Sofa.SharedKernel.BaseClasses.Exceptions;

namespace Sofa.CourseManagement.DomainService
{
    public class TermDomainService : ITermDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TermDomainService(IUnitOfWork uniteOfWork)
        {
            _unitOfWork = uniteOfWork;
        }

        public void CanAdd(string title)
        {
            var isDuplicatedTitle = _unitOfWork.termRepository.Any(c => c.Title.Equals(title));
            if (isDuplicatedTitle)
            {
                throw new BusinessException("نام وارد شده تکراری است");
            }
        }
    }
}
