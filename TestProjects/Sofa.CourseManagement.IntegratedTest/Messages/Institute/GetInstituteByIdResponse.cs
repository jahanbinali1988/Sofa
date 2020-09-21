using Sofa.CourseManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetInstituteByIdResponse : ResponseBase
    {
        public Institute Institute { get; set; }
    }
}
