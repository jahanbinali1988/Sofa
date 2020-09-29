using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeletePostRequest : LoginRequiredRequest
    {
        public Guid Id { get; set; }
    }
}
