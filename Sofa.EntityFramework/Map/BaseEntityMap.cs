using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sofa.EntityFramework.Map
{
    public abstract class BaseEntityMap<TEntity>
        where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
