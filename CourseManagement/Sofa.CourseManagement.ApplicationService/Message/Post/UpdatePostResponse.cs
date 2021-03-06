﻿using Sofa.SharedKernel.BaseClasses;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdatePostResponse : ResponseBase
    {
        public UpdatePostResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdatePostResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }
    }
}
