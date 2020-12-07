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

        public static User CreateInstance(Guid? id, bool isActive, string description)
        {
            var user = new User();
            user.Id = id.HasValue ? id.Value : Guid.NewGuid();
            user.AssignCreateDate(DateTime.Now);
            user.AssignFirstRowVersion();
            user.AssignIsActive(isActive);
            user.AssignIsDeleted(false);
            user.AssignDescription(description);

            return user;
        }
        public static User CreateInstance(Guid? id, string firstName, string lastname, string rawPassword, string emailAddress, string userName,
            UserRoleEnum role, string phoneNo, LevelEnum level, bool isActive, string description)
        {
            var user = CreateInstance(id, isActive, description);
            user.AssignFirstName(firstName);
            user.AssignLastName(lastname);
            user.ChangePassword(rawPassword);
            user.AssignEmail(emailAddress);
            user.AssignUserName(userName);
            user.AssignRole(role);
            user.AssignPhoneNumber(phoneNo);
            user.AssignLevel(level);

            return user;
        }
    }
}
