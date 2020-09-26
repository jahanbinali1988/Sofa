using System;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddPostResponse : AddResponseBase
    {
        public AddPostResponse(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message, errorMessage, newRecordedId)
        {
        }
        public AddPostResponse(Guid newRecordedId) : base(newRecordedId)
        {
        }
    }
}
