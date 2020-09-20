using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.EntityFramework.Mapper;
using Sofa.EntityFramework.Extention;

namespace Sofa.CourseManagement.EntityFramework.Context
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
            builder.AddConfiguration(new InstituteMapper());
            builder.AddConfiguration(new LessonPlanMapper());
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
