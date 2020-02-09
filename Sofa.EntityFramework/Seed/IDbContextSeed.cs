using Microsoft.EntityFrameworkCore;

namespace Sofa.EntityFramework.Seed
{
    public interface IDbContextSeed
    {
        void Seed(ModelBuilder modelBuilder);
    }
}
