using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Map;

namespace Sofa.CourseManagement.EntityFramework.Mapper
{
    class TermMapper : BaseEntityMap<Term>
    {
        public override void Map(EntityTypeBuilder<Term> builder)
        {
            builder.ToTable("Term");
            builder.HasKey(x => x.Id).HasName("PK_Term");

            builder.HasOne<Course>(c => c.Course);
            builder.HasMany<Session>(c => c.Sessions);

        }
    }
}
