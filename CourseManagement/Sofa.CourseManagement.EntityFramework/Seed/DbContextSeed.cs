using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Seed;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.EntityFramework.Seed
{
    public class DbContextSeed : IDbContextSeed
    {
        private readonly IConfiguration configuration;

        public DbContextSeed(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            var userSysAdmin = new User
            {
                Id = DefaultData.SysAdminId,
                CreateDate = DateTime.Now,
                Description = string.Empty,
                Email = "jahanbin.ali1988@gmail.com",
                FirstName = "Ali",
                IsActive = true,
                LastName = "Jahanbin",
                ModifyDate = DateTime.Now,
                PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(DefaultData.SysAdminPassword),
                PhoneNumber = "09224957626",
                Role = UserRoleEnum.SysAdmin,
                RowVersion = 0,
                UserName = DefaultData.SysAdminUsername,
                Level = LevelEnum.Advanced
            };
            var userTeacher = new User
            {
                Id = DefaultData.TeacherUserId,
                CreateDate = DateTime.Now,
                Description = string.Empty,
                Email = "jahanbinali88@yahoo.com",
                FirstName = "Ali",
                IsActive = true,
                LastName = "Jahanbin",
                ModifyDate = DateTime.Now,
                PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(DefaultData.TeacherPassword),
                PhoneNumber = "09224957626",
                Role = UserRoleEnum.Teacher,
                RowVersion = 0,
                UserName = DefaultData.TeacherUsername,
                Level = LevelEnum.Advanced
            };
            var userStudent = new User
            {
                Id = DefaultData.StudentId,
                CreateDate = DateTime.Now,
                Description = string.Empty,
                Email = "jahanbin.ali1988@yahoo.com",
                FirstName = "Ali",
                IsActive = true,
                LastName = "Jahanbin",
                ModifyDate = DateTime.Now,
                PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(DefaultData.StudentPassword),
                PhoneNumber = "09224957626",
                Role = UserRoleEnum.Teacher,
                RowVersion = 0,
                UserName = DefaultData.StudentUsername,
                Level = LevelEnum.Begginer
            };

            var defaultInstitute = Institute.CreateInstance(DefaultData.defaultInstituteId, "TestInstitute", true, Guid.NewGuid().ToString());

            var defaultField = Field.CreateInstance(DefaultData.defaultFieldId, "DefaultField", true, defaultInstitute.Id);

            var defaultCourse = Course.CreateInstance(DefaultData.defaultCourseId, "DefaultCourse", "", true, defaultField.Id);

            var defaultTerm = Term.CreateInstance(DefaultData.defaultTermId, "DefaultTerm", true, defaultCourse.Id);

            var defaultLessonPlan = LessonPlan.CreateInstance(DefaultData.defaultLessonPlanId, SharedKernel.Enum.LevelEnum.Begginer, true);

            var defaultSession = Session.CreateInstance(DefaultData.defaultSessionId, "DefaultSession", true, defaultLessonPlan.Id, defaultTerm.Id);

            var defaultPost = Post.CreateInstance(DefaultData.defaultPostId, "DefaultPost", 1, SharedKernel.Enum.PostTypeEnum.Text, defaultLessonPlan.Id, true);

            modelBuilder.Entity<Institute>().HasData(defaultInstitute);
            modelBuilder.Entity<Field>().HasData(defaultField);
            modelBuilder.Entity<Course>().HasData(defaultCourse);
            modelBuilder.Entity<Term>().HasData(defaultTerm);
            modelBuilder.Entity<LessonPlan>().HasData(defaultLessonPlan);
            modelBuilder.Entity<Session>().HasData(defaultSession);
            modelBuilder.Entity<Post>().HasData(defaultPost);
            modelBuilder.Entity<User>().HasData(userSysAdmin, userTeacher, userStudent);
        }
    }
}
