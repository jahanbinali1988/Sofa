using Microsoft.EntityFrameworkCore;

namespace Sofa.EntityFramework.Map
{
    public interface IEntityTypeMap
    {
        void Map(ModelBuilder builder);
    }
}
