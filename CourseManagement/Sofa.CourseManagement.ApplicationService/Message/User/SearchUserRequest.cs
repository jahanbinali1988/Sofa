using Sofa.SharedKernel.BaseClasses.Message;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SearchUserRequest : RequestWithPaging
    {
        public string Caption { get; set; }
    }
}
