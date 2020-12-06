using Sofa.SharedKernel.BaseClasses.Message;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchTermRequest : RequestWithPaging
    {
        public string Caption { get; set; }
    }
}
