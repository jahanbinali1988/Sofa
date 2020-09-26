using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Sofa.CourseManagement.EntityFramework.Context;

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

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(new ConnectionStringProvider(configuration).GetConnectionString(), x => x.MigrationsAssembly("Sofa.CourseManagement.EntityFramework"))
                .Options;
            var applicationContextOptions = new ApplicationDbContextOptions(dbContextOptions, null, null);
            var testContext = new ApplicationDbContext(applicationContextOptions);

            //testContext.Database.ExecuteSqlCommand("exec CleanDatabase");
            //var contextservice = testContext.GetService<IMigrator>();
            //contextservice.Migrate();
            //AddDefaultData(testContext);
        }

        private static void AddDefaultData(ApplicationDbContext context)
        {

        }
    }
}
