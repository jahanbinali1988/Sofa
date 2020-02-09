using Microsoft.EntityFrameworkCore;
using Sofa.EntityFramework.Map;
using Sofa.EntityFramework.Seed;
using System.Collections.Generic;

namespace Sofa.CourseManagement.EntityFramework.Context
{
    public class ApplicationDbContextOptions
    {
        public readonly DbContextOptions<ApplicationDbContext> Options;
        public readonly IDbContextSeed DbContextSeed;
        public readonly IEnumerable<IEntityTypeMap> Mappings;

        public ApplicationDbContextOptions(DbContextOptions<ApplicationDbContext> options, IDbContextSeed dbContextSeed, IEnumerable<IEntityTypeMap> mappings)
        {
            DbContextSeed = dbContextSeed;
            Options = options;
            Mappings = mappings;
        }
    }
}
