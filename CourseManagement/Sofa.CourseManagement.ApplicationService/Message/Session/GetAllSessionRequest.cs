using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllSessionRequest : RequestWithPaging
    {
        public Guid TermId { get; set; }
    }
}
