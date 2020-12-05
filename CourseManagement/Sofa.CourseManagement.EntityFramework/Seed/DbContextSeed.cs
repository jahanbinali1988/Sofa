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
            var userSysAdmin = User.CreateInstance(DefaultData.SysAdminId, "Ali", "Jahanbin", DefaultData.SysAdminPassword, "jahanbin.ali1988@gmail.com", DefaultData.SysAdminUsername, UserRoleEnum.SysAdmin, "09224957626", true, string.Empty, LevelEnum.Intermediate);
            var userTeacher = User.CreateInstance(DefaultData.TeacherUserId,"Ali", "Jahanbin", DefaultData.TeacherPassword, "jahanbin.ali1988@gmail.com", DefaultData.TeacherUsername, UserRoleEnum.Teacher, "09224957626", true, string.Empty, LevelEnum.Advanced);
            var userStudent = User.CreateInstance(DefaultData.StudentId, "Ali", "Jahanbin", DefaultData.SysAdminPassword, "jahanbin.ali1988@gmail.com", DefaultData.SysAdminUsername, UserRoleEnum.Student, "09224957626", true, string.Empty, LevelEnum.Begginer);
            
            var defaultInstitute = Institute.CreateInstance(DefaultData.InstituteId, "TestInstitute", true, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            var defaultField = Field.CreateInstance(DefaultData.FieldId, "DefaultField", true, defaultInstitute.Id, string.Empty);

            var defaultCourse = Course.CreateInstance(DefaultData.CourseId, "DefaultCourse", AgeRangeEnum.Adults, true, defaultField.Id, string.Empty);

            var defaultTerm = Term.CreateInstance(DefaultData.TermId, "DefaultTerm", true, defaultCourse.Id, string.Empty);

            var defaultLessonPlan = LessonPlan.CreateInstance(DefaultData.LessonPlanId, SharedKernel.Enum.LevelEnum.Begginer, true, string.Empty);

            var defaultSession = Session.CreateInstance(DefaultData.SessionId, "DefaultSession", true, defaultLessonPlan.Id, defaultTerm.Id, string.Empty);

            var defaultPost = Post.CreateInstance(DefaultData.PostId, "DefaultPost", 1, SharedKernel.Enum.ContentTypeEnum.Text, "Sample Content",defaultLessonPlan.Id, true, string.Empty);

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
