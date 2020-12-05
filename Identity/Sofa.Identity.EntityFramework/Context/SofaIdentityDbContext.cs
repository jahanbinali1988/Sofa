using Microsoft.EntityFrameworkCore;
using Sofa.Identity.EntityFramework.Extention;
using Sofa.Identity.EntityFramework.Map;
using Sofa.Identity.EntityFramework.Map.Mapper;
using Sofa.Identity.EntityFramework.Seed;
using System.Collections.Generic;

namespace Sofa.Identity.EntityFramework.Context
{
    public class SofaIdentityDbContext : DbContext
    {
        private readonly SofaIdentityDbContextOptions options;
        public SofaIdentityDbContext(SofaIdentityDbContextOptions options)
            : base(options.Options)
        {
            this.options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddConfiguration(new UserMapper());

            base.OnModelCreating(builder);

            foreach (var mapping in options.Mappings)
            {
                mapping.Map(builder);
            }

            options.DbContextSeed?.Seed(builder);
        }
    }

    public class SofaIdentityDbContextOptions
    {
        public readonly DbContextOptions<SofaIdentityDbContext> Options;
        public readonly IDbContextSeed DbContextSeed;
        public readonly IEnumerable<IEntityTypeMap> Mappings;

        public SofaIdentityDbContextOptions(DbContextOptions<SofaIdentityDbContext> options, IDbContextSeed dbContextSeed, IEnumerable<IEntityTypeMap> mappings)
        {
            DbContextSeed = dbContextSeed;
            Options = options;
            Mappings = mappings;
        }
    }

    public static class SofaIdentityDbContextExtensions
    {
        public static DbSet<TEntityType> DbSet<TEntityType>(this SofaIdentityDbContext context)
            where TEntityType : class
        {
            return context.Set<TEntityType>();
        }
    }
}
