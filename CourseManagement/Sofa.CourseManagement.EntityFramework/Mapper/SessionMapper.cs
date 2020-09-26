using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Map;

namespace Sofa.CourseManagement.EntityFramework.Mapper
{
    public class SessionMapper : BaseEntityMap<Session>
    {
        public override void Map(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Session");
            builder.HasKey(x => x.Id).HasName("PK_Session");

            builder.HasOne<Term>(c => c.Term);
            builder.HasOne(a => a.LessonPlan).WithOne(b => b.Session).HasForeignKey<LessonPlan>(c=> c.SessionId);
        }
    }
}
