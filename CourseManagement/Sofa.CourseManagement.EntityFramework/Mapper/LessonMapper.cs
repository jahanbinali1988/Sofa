using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Map;

namespace Sofa.CourseManagement.EntityFramework.Mapper
{
    public class LessonMapper : BaseEntityMap<Lesson>
    {
        public override void Map(EntityTypeBuilder<Lesson> builder)
        {
            builder
                .ToTable("Lesson");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Lesson");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Title)
                .HasColumnName("Title");
        }
    }
}
