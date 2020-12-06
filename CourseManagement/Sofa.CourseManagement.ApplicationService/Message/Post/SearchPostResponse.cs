using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchPostResponse : ResponseBase
    {
        public SearchPostResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public SearchPostResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<PostDto> Posts { get; set; }
    }
}
