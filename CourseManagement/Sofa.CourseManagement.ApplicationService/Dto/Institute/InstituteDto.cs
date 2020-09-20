using Sofa.CourseManagement.Model;
using System.Collections.Generic;

namespace Sofa.CourseManagement.ApplicationService
{
    public class InstituteDto
    {
        public ICollection<Address> Addresses { get; set; }
        public string Title { get; set; }
    }
}
