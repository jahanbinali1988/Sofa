using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class LessonPlanMapper : BaseEntityMap<Model.LessonPlan>
    {
        public override void Map(EntityTypeBuilder<Model.LessonPlan> builder)
        {
            builder
                .ToTable("LessonPlan");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_LessonPlan");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
