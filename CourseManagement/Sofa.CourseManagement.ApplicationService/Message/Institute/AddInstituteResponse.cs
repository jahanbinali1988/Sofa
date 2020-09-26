using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddInstituteResponse : AddResponseBase
    {
        public AddInstituteResponse()
        {
        }

        public AddInstituteResponse(Guid newRecordedId) : base(newRecordedId)
        {
        }

        public AddInstituteResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
        }
    }
}
