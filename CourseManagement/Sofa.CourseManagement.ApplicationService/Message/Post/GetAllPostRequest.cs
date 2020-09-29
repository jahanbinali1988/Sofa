using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllPostRequest : RequestWithPaging
    {
        public Guid LessonPlanId { get; set; }
    }
}
