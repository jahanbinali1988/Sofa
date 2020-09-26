using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddTermResponse : AddResponseBase
    {
        public AddTermResponse()
        {
        }

        public AddTermResponse(Guid newRecordedId) : base(newRecordedId)
        {
        }

        public AddTermResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
        }
    }
}
