using System.Collections.Generic;

namespace Sofa.SharedKernel.BaseClasses
{
    public class ResponseBase
    {
        public ResponseBase(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public ResponseBase(bool isSuccess, string message, string errorMessage) : this(isSuccess, message)
        {
            this.ErrorMessage = errorMessage;
        }

        public bool IsSuccess { get; internal set; }
        public string Message { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public int ResponseStatusCode { get; internal set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
