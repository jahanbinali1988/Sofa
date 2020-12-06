using Sofa.SharedKernel.BaseClasses.Message;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchInstituteRequest : RequestWithPaging
    {
        public string Caption { get; set; }
    }
}
