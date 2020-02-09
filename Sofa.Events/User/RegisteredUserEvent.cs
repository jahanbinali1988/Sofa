using System;

namespace Sofa.Events.User
{
    public class RegisteredUserEvent
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public short Role { get; set; }
        public short Level { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
