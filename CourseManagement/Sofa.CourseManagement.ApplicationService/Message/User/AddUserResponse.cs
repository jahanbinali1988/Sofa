using System;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddUserResponse : ResponseBase
    {
        public AddUserResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AddUserResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public Guid NewRecordedId { get; set; }
    }
}
