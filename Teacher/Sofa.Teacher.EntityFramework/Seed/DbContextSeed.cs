using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sofa.EntityFramework.Seed;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.EntityFramework.Seed
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
            var userSysAdmin = User.CreateInstance(DefaultData.SysAdminId, "Ali", "Jahanbin", "jahanbin.ali1988@gmail.com", DefaultData.SysAdminUsername, LevelEnum.Intermediate, "09224957626", Guid.Empty, true, string.Empty);
            var userTeacher = User.CreateInstance(DefaultData.TeacherUserId, "Ali", "Jahanbin", "jahanbin.ali1988@gmail.com", DefaultData.TeacherUsername, LevelEnum.Advanced, "09224957626", Guid.Empty, true, string.Empty); ;
            var userStudent = User.CreateInstance(DefaultData.StudentId, "Ali", "Jahanbin", "jahanbin.ali1988@gmail.com", DefaultData.SysAdminUsername, LevelEnum.Begginer, "09224957626", Guid.Empty, true, string.Empty);

            modelBuilder.Entity<User>()
                .HasData(userSysAdmin, userTeacher, userStudent);
        }
    }
}
