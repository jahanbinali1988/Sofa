using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class InstituteMapper : BaseEntityMap<Model.Institute>
    {
        public override void Map(EntityTypeBuilder<Model.Institute> builder)
        {
            builder
                .ToTable("Institute");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Institute");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
