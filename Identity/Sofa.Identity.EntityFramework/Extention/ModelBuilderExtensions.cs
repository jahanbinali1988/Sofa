using Microsoft.EntityFrameworkCore;
using Sofa.Identity.EntityFramework.Map;

namespace Sofa.Identity.EntityFramework.Extention
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, BaseEntityMap<TEntity> configuration)
            where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}
