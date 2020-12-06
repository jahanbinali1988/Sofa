using Sofa.SharedKernel.BaseClasses.Message;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchFieldRequest : RequestWithPaging
    {
        public string Caption { get; set; }
    }
}
