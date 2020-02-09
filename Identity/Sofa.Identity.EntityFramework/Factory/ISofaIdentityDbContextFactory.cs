using Sofa.Identity.EntityFramework.Context;

namespace Sofa.Identity.EntityFramework.Factory
{
    public interface ISofaIdentityDbContextFactory
    {
        SofaIdentityDbContext Create();
    }
}
