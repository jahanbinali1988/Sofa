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

        DbContext IApplicationDbContextFactory.Create()
        {
            return new ApplicationDbContext(options);
        }
    }
}
