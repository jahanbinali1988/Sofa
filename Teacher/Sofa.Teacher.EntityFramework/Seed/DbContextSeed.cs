using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sofa.EntityFramework.Seed;
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
            var userSysAdmin = new User
            {
                Id = Guid.Parse("731874E2-B89C-4509-819A-5B69396A336B"),
                CreateDate = DateTime.Now,
                Description = string.Empty,
                Email = "jahanbin.ali1988@gmail.com",
                FirstName = "Ali",
                IsActive = true,
                LastName = "Jahanbin",
                ModifyDate = DateTime.Now,
                PhoneNumber = "09224957626",
                RowVersion = 0,
                UserName = "09224957626",
                Level = LevelEnum.Advanced,
                LastCourseId = Guid.Empty
            };
            var userTeacher = new User
            {
                Id = Guid.Parse("253E472E-21AC-4864-B218-B364169D0611"),
                CreateDate = DateTime.Now,
                Description = string.Empty,
                Email = "jahanbinali88@yahoo.com",
                FirstName = "Ali",
                IsActive = true,
                LastName = "Jahanbin",
                ModifyDate = DateTime.Now,
                PhoneNumber = "09389459731",
                RowVersion = 0,
                UserName = "09389459731",
                Level = LevelEnum.Intermediate,
                LastCourseId = Guid.Empty
            };
            var userStudent = new User
            {
                Id = Guid.Parse("50ECC8E1-5C5C-4A97-A5F5-AF9E9EBA1B70"),
                CreateDate = DateTime.Now,
                Description = string.Empty,
                Email = "jahanbin.ali1988@yahoo.com",
                FirstName = "Ali",
                IsActive = true,
                LastName = "Jahanbin",
                ModifyDate = DateTime.Now,
                PhoneNumber = "09370429731",
                RowVersion = 0,
                UserName = "09370429731",
                Level = LevelEnum.Begginer,
                LastCourseId = Guid.Empty
            };

            modelBuilder.Entity<User>()
                .HasData(userSysAdmin, userTeacher, userStudent);
        }
    }
}
