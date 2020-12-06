using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class ChangeActiveStatusUserRequest : LoginRequiredRequest
    {
        public Guid Id { get; set; }
    }
}
