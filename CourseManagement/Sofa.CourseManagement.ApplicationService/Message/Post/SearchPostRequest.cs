using Sofa.SharedKernel.BaseClasses.Message;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchPostRequest : RequestWithPaging
    {
        public string Caption { get; set; }
    }
}
