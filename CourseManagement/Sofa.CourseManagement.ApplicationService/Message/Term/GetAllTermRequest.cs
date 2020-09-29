using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllTermRequest : RequestWithPaging
    {
        public Guid CourseId { get; set; }
    }
}
