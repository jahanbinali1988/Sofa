using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddPostResponse : ResponseBase
    {
        public AddPostResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AddPostResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public Guid NewRecordedId { get; set; }
    }
}
