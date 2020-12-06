using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class SessionMapper : BaseEntityMap<Model.Session>
    {
        public override void Map(EntityTypeBuilder<Model.Session> builder)
        {
            builder
                .ToTable("Session");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Session");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
