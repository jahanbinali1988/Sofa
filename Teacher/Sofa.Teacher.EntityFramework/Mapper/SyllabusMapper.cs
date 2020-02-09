using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;
using Sofa.Teacher.Model;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class SyllabusMapper : BaseEntityMap<Syllabus>
    {
        public override void Map(EntityTypeBuilder<Syllabus> builder)
        {
            builder
                .ToTable("Syllabus");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Syllabus");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
