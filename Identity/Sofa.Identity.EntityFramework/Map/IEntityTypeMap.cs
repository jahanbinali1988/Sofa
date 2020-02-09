using Microsoft.EntityFrameworkCore;

namespace Sofa.Identity.EntityFramework.Map
{
    public interface IEntityTypeMap
    {
        void Map(ModelBuilder builder);
    }
}
