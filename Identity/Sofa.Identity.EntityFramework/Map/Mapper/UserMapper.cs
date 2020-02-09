using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.Identity.Model;

namespace Sofa.Identity.EntityFramework.Map.Mapper
{
    public class UserMapper : BaseEntityMap<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("IDN_User");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_IDN_User");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

        }
    }
}
