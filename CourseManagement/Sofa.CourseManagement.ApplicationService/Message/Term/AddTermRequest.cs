using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddTermRequest : LoginRequiredRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public Guid CourseId { get; set; }
    }
}
