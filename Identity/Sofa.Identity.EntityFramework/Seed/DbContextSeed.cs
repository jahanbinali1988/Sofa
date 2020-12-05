using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sofa.Identity.Model;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;

namespace Sofa.Identity.EntityFramework.Seed
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
            var userSysAdmin = User.CreateInstance(DefaultData.SysAdminId, "Ali", "Jahanbin", DefaultData.SysAdminPassword, "jahanbin.ali1988@gmail.com", DefaultData.SysAdminUsername, UserRoleEnum.SysAdmin, "09224957626", true, null, null, string.Empty, LevelEnum.Intermediate);
            var userTeacher = User.CreateInstance(DefaultData.TeacherUserId, "Ali", "Jahanbin", DefaultData.TeacherPassword, "jahanbin.ali1988@gmail.com", DefaultData.TeacherUsername, UserRoleEnum.Teacher, "09224957626", true, null, null, string.Empty, LevelEnum.Advanced);
            var userStudent = User.CreateInstance(DefaultData.StudentId, "Ali", "Jahanbin", DefaultData.StudentPassword, "jahanbin.ali1988@gmail.com", DefaultData.StudentUsername, UserRoleEnum.Student, "09224957626", true, null, null, string.Empty, LevelEnum.Begginer);

            modelBuilder.Entity<User>()
                .HasData(userSysAdmin, userTeacher, userStudent);
        }
    }
}
