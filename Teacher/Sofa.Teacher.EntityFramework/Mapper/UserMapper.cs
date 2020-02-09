using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;
using Sofa.Teacher.Model;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class UserMapper : BaseEntityMap<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_User");
        }
    }
}
