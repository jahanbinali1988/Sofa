using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class FieldMapper : BaseEntityMap<Model.Field>
    {
        public override void Map(EntityTypeBuilder<Model.Field> builder)
        {
            builder
                .ToTable("Field");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Field");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
