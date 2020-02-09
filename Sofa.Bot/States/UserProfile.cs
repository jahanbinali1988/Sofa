using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Teacher.States
{
    // Defines a state property used to track information about the user.
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public LevelEnum Level { get; set; }
        public Guid LastPassedPost { get; set; }
        public Guid? LastPassedCourse { get; set; }
    }
}
