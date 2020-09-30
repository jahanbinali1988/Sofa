using Sofa.CourseManagement.Repository;
using Sofa.SharedKernel.BaseClasses.Exceptions;

namespace Sofa.CourseManagement.DomainService
{
    public class SessionDomainService : ISessionDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SessionDomainService(IUnitOfWork uniteOfWork)
        {
            _unitOfWork = uniteOfWork;
        }

        public void CanAdd(string title)
        {
            var isDuplicatedTitle = _unitOfWork.sessionRepository.Any(c => c.Title.Equals(title));
            if (isDuplicatedTitle)
            {
                throw new BusinessException("نام وارد شده تکراری است");
            }
        }
    }
}
