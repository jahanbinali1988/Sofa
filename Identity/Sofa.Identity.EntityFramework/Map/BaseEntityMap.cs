using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sofa.Identity.EntityFramework.Map
{
    public abstract class BaseEntityMap<TEntity>
        where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
