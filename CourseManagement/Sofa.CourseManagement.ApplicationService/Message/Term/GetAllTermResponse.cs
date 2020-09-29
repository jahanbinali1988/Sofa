using Sofa.SharedKernel.BaseClasses;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllTermResponse : ResponseBase
    {
        public GetAllTermResponse(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetAllTermResponse(bool isSuccess, string message, string errorMessage) : base(isSuccess, message, errorMessage)
        {
        }

        public IEnumerable<TermDto> Terms { get; set; }
    }
}
