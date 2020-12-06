using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class TermMapper : BaseEntityMap<Model.Term>
    {
        public override void Map(EntityTypeBuilder<Model.Term> builder)
        {
            builder
                .ToTable("Term");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Term");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
