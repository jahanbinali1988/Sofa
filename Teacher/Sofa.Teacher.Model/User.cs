using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Teacher.Model
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public LevelEnum Level { get; set; }
        public Guid? LastCourseId { get; set; }

        public Course Course { get; set; }

        public static User DefaultFactory(string firstName, string lastname, string emailAddress, string userName,
            LevelEnum level, string phoneNo, bool isActive, Guid? lastCourseId)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastname,
                UserName = userName,
                Email = emailAddress,
                IsActive = isActive,
                PhoneNumber = phoneNo,
                CreateDate = DateTime.Now,
                Level = level,
                LastCourseId = lastCourseId,
                ModifyDate = DateTime.Now,
                Description = string.Empty,
                RowVersion = 1
            };
        }
    }
}
