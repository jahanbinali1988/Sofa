using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Map;

namespace Sofa.CourseManagement.EntityFramework.Mapper
{
    public class FieldMapper : BaseEntityMap<Field>
    {
        public override void Map(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Field");
            builder.HasKey(x => x.Id).HasName("PK_Field");

            builder.HasOne<Institute>(c => c.Institute);
            builder.HasMany<Course>(c => c.Courses);
        }
    }
}
