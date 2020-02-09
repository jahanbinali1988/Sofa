using Microsoft.EntityFrameworkCore;
using Sofa.EntityFramework.Factory;
using Sofa.Teacher.EntityFramework.Context;

namespace Sofa.Teacher.EntityFramework.Factory
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
