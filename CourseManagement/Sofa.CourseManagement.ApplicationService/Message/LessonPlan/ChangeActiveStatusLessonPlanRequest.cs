using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class ChangeActiveStatusLessonPlanRequest : LoginRequiredRequest
    {
        public Guid Id { get; set; }
    }
}
