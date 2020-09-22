using Microsoft.EntityFrameworkCore;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.EntityFramework.Context
{
    public static class DbContextExtensions
    {
        public static DbSet<TEntityType> DbSet<TEntityType>(this DbContext context)
            where TEntityType : BaseEntity //class
        {
            return context.Set<TEntityType>();
        }
    }
}
