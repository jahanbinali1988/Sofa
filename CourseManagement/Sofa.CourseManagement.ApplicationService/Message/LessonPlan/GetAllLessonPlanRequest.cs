using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllLessonPlanRequest : RequestWithPaging
    {
        public Guid SessionId { get; set; }
    }
}
