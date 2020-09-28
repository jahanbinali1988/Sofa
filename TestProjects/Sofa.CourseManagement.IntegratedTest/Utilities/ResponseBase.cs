using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Utilities
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public int ResponseStatusCode { get; set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
