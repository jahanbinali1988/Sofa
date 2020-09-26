using System;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddUserResponse : AddResponseBase
    {
        public AddUserResponse()
        {
        }

        public AddUserResponse(Guid newRecordedId) : base(newRecordedId)
        {
        }

        public AddUserResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
        }
    }
}
