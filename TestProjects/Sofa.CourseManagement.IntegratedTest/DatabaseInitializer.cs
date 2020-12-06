using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.CourseManagement.EntityFramework.Factory;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using Sofa.EntityFramework.Map;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest
{
    public static class DatabaseInitializer
    {
        private static bool rebuilded;

        static DatabaseInitializer()
        {
            rebuilded = false;
        }

        public static void RebuildDatabase(IConfiguration configuration)
        {
            if (rebuilded)
                return;

            rebuilded = true;

            var connectionString = new ConnectionStringProvider(configuration).GetConnectionString();
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString, x => x.MigrationsAssembly("Sofa.CourseManagement.EntityFramework"))
                .EnableSensitiveDataLogging()
                .Options;
            var testSeed = new TestDBContextSeed();
            var mapperList = new List<IEntityTypeMap>();

            var applicationContextOptions = new ApplicationDbContextOptions(dbContextOptions, null, null);
            var contextFactory = new ApplicationDbContextFactory(applicationContextOptions);
            var sofaTestContext = contextFactory.Create();
        }
    }
}
