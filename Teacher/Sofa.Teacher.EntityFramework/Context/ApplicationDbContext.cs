using Microsoft.EntityFrameworkCore;
using Sofa.EntityFramework.Extention;
using Sofa.Teacher.EntityFramework.Mapper;

namespace Sofa.Teacher.EntityFramework.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContextOptions options;
        public ApplicationDbContext(ApplicationDbContextOptions options)
            : base(options.Options)
        {
            this.options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddConfiguration(new SyllabusMapper());
            builder.AddConfiguration(new CourseMapper());
            builder.AddConfiguration(new PostMapper());
            builder.AddConfiguration(new UserMapper());

            base.OnModelCreating(builder);

            foreach (var mapping in options.Mappings)
            {
                mapping.Map(builder);
            }

            options.DbContextSeed?.Seed(builder);
        }
    }
}
