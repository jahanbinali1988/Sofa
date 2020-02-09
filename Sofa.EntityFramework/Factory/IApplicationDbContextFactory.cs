using Microsoft.EntityFrameworkCore;

namespace Sofa.EntityFramework.Factory
{
    public interface IApplicationDbContextFactory
    {
        DbContext Create();
    }
}