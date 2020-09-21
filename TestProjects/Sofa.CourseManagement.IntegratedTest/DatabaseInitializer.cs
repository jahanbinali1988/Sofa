using Microsoft.EntityFrameworkCore;
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

            //context.database.executesqlcommand("exec cleandatabase");
            //var contextservice = context.getservice<imigrator>();
            //contextservice.migrate();
            //adddefaultdata(context);
        }

        private static void AddDefaultData(ApplicationDbContext context)
        {

        }
    }
}
