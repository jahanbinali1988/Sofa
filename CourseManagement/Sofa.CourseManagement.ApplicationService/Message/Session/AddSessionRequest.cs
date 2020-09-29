using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddSessionRequest : LoginRequiredRequest
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public Guid TermId { get; set; }
        public Guid LessonPlanId { get; set; }
    }
}
