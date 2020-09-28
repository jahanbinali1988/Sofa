using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddFieldResponse : ResponseBase
    {
        public AddFieldResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AddFieldResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public Guid NewRecordedId { get; set; }
    }
}
