using Sofa.SharedKernel.BaseClasses.Message;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class DeleteFieldRequest : LoginRequiredRequest
    {
        [GuidValidator(ErrorMessage = "وارد کردن شناسه الزامی است")]
        public Guid Id { get; set; }
    }
}
