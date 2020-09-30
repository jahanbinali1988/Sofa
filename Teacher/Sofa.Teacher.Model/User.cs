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
        public void AssignPhoneNumber(string phoneNumber) { this.PhoneNumber = phoneNumber; }
        public void AssignIsActive(bool isActive) { this.IsActive = isActive; }
        public void AssignLastCourse(Guid lastCourseId) { this.LastCourseId = lastCourseId; }
        public void AssignLastCourse(Course course) { this.LastCourseId = course.Id; this.Course = course; }
        public static User CreateInstance(Guid? id, string firstName, string lastname, string emailAddress, string userName,
            LevelEnum level, string phoneNo, bool isActive, Guid? lastCourseId, string description)
        {
            return new User
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastname,
                UserName = userName,
                Email = emailAddress,
                IsActive = isActive,
                PhoneNumber = phoneNo,
                CreateDate = DateTime.Now,
                Level = level,
                LastCourseId = lastCourseId,
                Description = description,
                RowVersion = 0
            };
        }
    }
}
