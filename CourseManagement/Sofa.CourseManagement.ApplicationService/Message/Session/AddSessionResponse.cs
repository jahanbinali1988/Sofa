using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddSessionResponse : ResponseBase
    {
        public AddSessionResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AddSessionResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public Guid NewRecordedId { get; set; }
    }
}
