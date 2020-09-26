using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddSessionResponse : AddResponseBase
    {
        public AddSessionResponse()
        {
        }

        public AddSessionResponse(Guid newRecordedId) : base(newRecordedId)
        {
        }

        public AddSessionResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
        }
    }
}
