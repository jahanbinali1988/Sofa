using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class SearchPostResponse : ResponseBase
    {
        public IEnumerable<PostDto> Posts { get; set; }
    }
}
