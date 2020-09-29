using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeleteLessonPlanRequest : LoginRequiredRequest
    {
        public Guid Id { get; set; }
    }
}
