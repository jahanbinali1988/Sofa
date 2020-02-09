using Sofa.Identity.EntityFramework.Context;

namespace Sofa.Identity.EntityFramework.Factory
{
    public class SofaIdentityDbContextFactory : ISofaIdentityDbContextFactory
    {
        private readonly SofaIdentityDbContextOptions options;

        public SofaIdentityDbContextFactory(SofaIdentityDbContextOptions options)
        {
            this.options = options;
        }

        SofaIdentityDbContext ISofaIdentityDbContextFactory.Create()
        {
            return new SofaIdentityDbContext(options);
        }
    }
}
