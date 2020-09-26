using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Map;

namespace Sofa.CourseManagement.EntityFramework.Mapper
{
    public class CourseMapper : BaseEntityMap<Course>
    {
        public override void Map(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(x => x.Id).HasName("PK_Course");

            builder.HasOne<Field>(c => c.Field);
            builder.HasMany<Term>(c => c.Terms);
        }
    }
}
