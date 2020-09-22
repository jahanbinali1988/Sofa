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
                Id = Guid.Parse("731874E2-B89C-4509-819A-5B69396A336B"),
                CreateDate = DateTime.Now,
                Description = string.Empty,
                Email = "jahanbin.ali1988@gmail.com",
                FirstName = "Ali",
                IsActive = true,
                LastName = "Jahanbin",
                ModifyDate = DateTime.Now,
                PasswordHash = SHA256HashGenerator.GenerateSHA256Hash("123456"),
                PhoneNumber = "09224957626",
                Role = UserRoleEnum.SysAdmin,
                RowVersion = 0,
                UserName = "sysadmin",
                Level = LevelEnum.Advanced
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
                PasswordHash = SHA256HashGenerator.GenerateSHA256Hash("123456"),
                PhoneNumber = "09224957626",
                Role = UserRoleEnum.Teacher,
                RowVersion = 0,
                UserName = "teacher",
                Level = LevelEnum.Advanced
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
                PasswordHash = SHA256HashGenerator.GenerateSHA256Hash("123456"),
                PhoneNumber = "09224957626",
                Role = UserRoleEnum.Teacher,
                RowVersion = 0,
                UserName = "student",
                Level = LevelEnum.Begginer
            };

            modelBuilder.Entity<User>().HasData(userSysAdmin, userTeacher, userStudent);
        }
    }
}
