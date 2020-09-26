namespace Sofa.CourseManagement.IntegratedTest
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public int ResponseStatusCode { get; set; }
    }
}
