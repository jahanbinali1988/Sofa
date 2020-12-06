using Sofa.SharedKernel.BaseClasses.Message;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchSessionRequest : RequestWithPaging
    {
        public string Caption { get; set; }
    }
}
