using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllFieldRequest : RequestWithPaging
    {
        public Guid InstituteId { get; set; }
    }
}
