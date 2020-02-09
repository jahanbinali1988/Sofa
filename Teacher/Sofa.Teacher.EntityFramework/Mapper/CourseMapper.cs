using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;
using Sofa.Teacher.Model;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class CourseMapper : BaseEntityMap<Course>
    {
        public override void Map(EntityTypeBuilder<Course> builder)
        {
            builder
                .ToTable("Course");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Course");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
