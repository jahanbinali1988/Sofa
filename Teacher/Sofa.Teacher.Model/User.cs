using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Teacher.Model
{
    public class User : BaseEntity
    {
        public string UserName { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string Email { get; internal set; }
        public LevelEnum Level { get; internal set; }

        public Guid? LastCourseId { get; internal set; }
        public Course Course { get; set; }

        internal User()
        {

        }

        public void AssignUserName(string userName) { this.UserName = userName; }
        public void AssignFirstName(string firsName) { this.FirstName = firsName; }
        public void AssignLastName(string lastName) { this.LastName = lastName; }
        public void AssignEmail(string email) { this.Email = email; }
        public void AssignLevel(LevelEnum level) { this.Level = level; }
        public void AssignLevel(short level) { this.Level = (LevelEnum)level; }
        public void AssignPhoneNumber(string phoneNumber) { this.PhoneNumber = phoneNumber; }
        public void AssignLastCourse(Guid lastCourseId) { this.LastCourseId = lastCourseId; }
        public void AssignLastCourse(Course course) { this.LastCourseId = course.Id; this.Course = course; }

        public static User CreateInstance(Guid? id, bool isActive, string description)
        {
            var user = new User();
            user.Id = id.HasValue ? id.Value : Guid.Empty;
            user.AssignCreateDate(DateTime.Now);
            user.AssignFirstRowVersion();
            user.AssignIsActive(isActive);
            user.AssignIsDeleted(false);
            user.AssignDescription(description);

            return user;
        }
        public static User CreateInstance(Guid? id, string firstName, string lastname, string emailAddress, string userName,
            LevelEnum level, string phoneNo, Guid lastCourseId, bool isActive, string description)
        {
            var user = CreateInstance(id, isActive, description);
            user.AssignFirstName(firstName);
            user.AssignLastName(lastname);
            user.AssignEmail(emailAddress);
            user.AssignUserName(userName);
            user.AssignLevel(level);
            user.AssignPhoneNumber(phoneNo);
            user.AssignLastCourse(lastCourseId);

            return user;
        }
        public static User CreateInstance(Guid? id, string firstName, string lastname, string emailAddress, string userName,
            short level, string phoneNo, Guid lastCourseId, bool isActive, string description)
        {
            var user = CreateInstance(id, isActive, description);
            user.AssignFirstName(firstName);
            user.AssignLastName(lastname);
            user.AssignEmail(emailAddress);
            user.AssignUserName(userName);
            user.AssignLevel(level);
            user.AssignPhoneNumber(phoneNo);
            user.AssignLastCourse(lastCourseId);

            return user;
        }
    }
}
