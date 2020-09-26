using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Map;

namespace Sofa.CourseManagement.EntityFramework.Mapper
{
    public class LessonPlanMapper : BaseEntityMap<LessonPlan>
    {
        public override void Map(EntityTypeBuilder<LessonPlan> builder)
        {
            builder.ToTable("LessonPlan");
            builder.HasKey(x => x.Id).HasName("PK_LessonPlan");

            builder.HasOne(a => a.Session).WithOne(b => b.LessonPlan).HasForeignKey<Session>(c => c.LessonPlanId);
            builder.HasMany<Post>(c => c.Posts);
        }
    }
}
