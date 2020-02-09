using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Identity.Model
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; }
        public LevelEnum Level { get; set; }
        public Guid? UserCurrentSyllabusId { get; set; }
        public Guid? UserCurrentCourseId { get; set; }
        public string UserTitle => FirstName + " " + LastName;

        public void ChangePassword(string newPassword)
        {
            PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(newPassword);
        }

        public static User DefaultFactory(string firstName, string lastname, string rawPassword, string emailAddress, string userName, UserRoleEnum role,
            string phoneNo, bool isActive, Guid? userCurrentSyllabusId, Guid? userCurrentCourseId)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastname,
                PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(rawPassword),
                UserName = userName,
                Email = emailAddress,
                Role = role,
                IsActive = isActive,
                PhoneNumber = phoneNo,
                UserCurrentCourseId = userCurrentCourseId,
                UserCurrentSyllabusId = userCurrentSyllabusId,
                CreateDate = DateTime.Now
            };
        }
    }
}
