using Microsoft.EntityFrameworkCore;

namespace Sofa.Teacher.EntityFramework.Context
{
    public static class DbContextExtensions
    {
        public static DbSet<TEntityType> DbSet<TEntityType>(this DbContext context)
            where TEntityType : class
        {
            return context.Set<TEntityType>();
        }
    }
}
