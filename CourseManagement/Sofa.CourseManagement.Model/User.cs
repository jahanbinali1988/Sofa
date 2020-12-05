using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.Model
{
    public class User : BaseEntity
    {
        public string UserName { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string PasswordHash { get; private set; }
        public string Email { get; internal set; }
        public UserRoleEnum Role { get; internal set; }
        public LevelEnum Level { get; internal set; }

        internal User()
        {

        }

        public void ChangePassword(string newPassword)
        {
            PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(newPassword);
        }
        public void AssignUserName(string userName) { this.UserName = userName; }
        public void AssignFirstName(string firstName) { this.FirstName = firstName; }
        public void AssignLastName(string lastName) { this.LastName = lastName; }
        public void AssignPhoneNumber(string phoneNumber) { this.PhoneNumber = phoneNumber; }
        public void AssignEmail(string email) { this.Email = email; }
        public void AssignRole(UserRoleEnum role) { this.Role = role; }
        public void AssignLevel(LevelEnum level) { this.Level = level; }
        public static User CreateInstance(Guid? id, string firstName, string lastname, string rawPassword, string emailAddress, string userName,
            UserRoleEnum role, string phoneNo, bool isActive, string description, LevelEnum level)
        {
            return new User
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastname,
                PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(rawPassword),
                UserName = userName,
                Email = emailAddress,
                Role = role,
                IsActive = isActive,
                PhoneNumber = phoneNo,
                CreateDate = DateTime.Now,
                Description = description,
                IsDeleted = false,
                Level = level,
                RowVersion = 0
            };
        }
    }
}
