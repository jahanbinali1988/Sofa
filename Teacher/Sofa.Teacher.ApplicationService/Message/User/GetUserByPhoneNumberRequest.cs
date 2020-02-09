using Sofa.SharedKernel.BaseClasses;

namespace Sofa.Teacher.ApplicationService
{
    public class GetUserByPhoneNumberRequest : RequestBase
    {
        public string PhoneNumber { get; set; }
    }
}
