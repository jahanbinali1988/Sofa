using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Map;

namespace Sofa.CourseManagement.EntityFramework.Mapper
{
    public class InstituteMapper : BaseEntityMap<Institute>
    {
        public override void Map(EntityTypeBuilder<Institute> builder)
        {
            builder.ToTable("Institute");
            builder.HasKey(x => x.Id).HasName("PK_Institute");
            builder.OwnsOne(typeof(Address), "Address");

            builder.HasMany<Field>(c => c.Fields);

        }
    }
}
