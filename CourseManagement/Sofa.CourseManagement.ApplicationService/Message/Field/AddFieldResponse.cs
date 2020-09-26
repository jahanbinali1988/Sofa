using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddFieldResponse : AddResponseBase
    {
        public AddFieldResponse()
        {
        }

        public AddFieldResponse(Guid newRecordedId) : base(newRecordedId)
        {
        }

        public AddFieldResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
        }
    }
}
