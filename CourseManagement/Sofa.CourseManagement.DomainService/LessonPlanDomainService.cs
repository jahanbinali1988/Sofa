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

    }
}
