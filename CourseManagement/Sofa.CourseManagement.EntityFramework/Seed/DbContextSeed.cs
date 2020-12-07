using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Seed;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;
using System;

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
            var userSysAdmin = User.CreateInstance(DefaultData.SysAdminId, "Ali", "Jahanbin", DefaultData.SysAdminPassword, "jahanbin.ali1988@gmail.com", DefaultData.SysAdminUsername, UserRoleEnum.SysAdmin, "09224957626", LevelEnum.Intermediate, true, string.Empty);
            var userTeacher = User.CreateInstance(DefaultData.TeacherUserId, "Ali", "Jahanbin", DefaultData.TeacherPassword, "jahanbin.ali1988@gmail.com", DefaultData.TeacherUsername, UserRoleEnum.Teacher, "09224957626", LevelEnum.Advanced, true, string.Empty);
            var userStudent = User.CreateInstance(DefaultData.StudentId, "Ali", "Jahanbin", DefaultData.SysAdminPassword, "jahanbin.ali1988@gmail.com", DefaultData.SysAdminUsername, UserRoleEnum.Student, "09224957626", LevelEnum.Begginer, true, string.Empty);

            var defaultInstitute = Institute.CreateInstance(DefaultData.InstituteId, "TestInstitute", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, Guid.NewGuid().ToString());

            var defaultField = Field.CreateInstance(DefaultData.FieldId, "DefaultField", defaultInstitute.Id, true, string.Empty);

            var defaultCourse = Course.CreateInstance(DefaultData.CourseId, "DefaultCourse", AgeRangeEnum.Adults, defaultField.Id, true, string.Empty);

            var defaultTerm = Term.CreateInstance(DefaultData.TermId, "DefaultTerm", defaultCourse.Id, true, string.Empty);

            var defaultLessonPlan = LessonPlan.CreateInstance(DefaultData.LessonPlanId, LevelEnum.Begginer, DefaultData.SessionId, true, string.Empty);

            var defaultSession = Session.CreateInstance(DefaultData.SessionId, "DefaultSession", defaultLessonPlan.Id, defaultTerm.Id, true, string.Empty);

            var defaultPost = Post.CreateInstance(DefaultData.PostId, "DefaultPost", 1, ContentTypeEnum.Text, "Sample Content", defaultLessonPlan.Id, true, string.Empty);

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
