using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.EntityFramework.Factory;

namespace Sofa.CourseManagement.EntityFramework.Factory
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly ApplicationDbContextOptions options;

        public ApplicationDbContextFactory(ApplicationDbContextOptions options)
        {
            this.options = options;
        }

        public DbContext Create()
        {
            return new ApplicationDbContext(options);
        }
    }
}
