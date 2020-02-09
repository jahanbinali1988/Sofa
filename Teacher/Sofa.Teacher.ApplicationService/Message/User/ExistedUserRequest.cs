using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sofa.Teacher.ApplicationService
{
    public class ExistedUserRequest : RequestBase
    {
        public string PhoneNumber { get; set; }
    }
}
