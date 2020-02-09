using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.EntityFramework.Map;
using Sofa.Teacher.Model;

namespace Sofa.Teacher.EntityFramework.Mapper
{
    public class PostMapper : BaseEntityMap<Post>
    {
        public override void Map(EntityTypeBuilder<Post> builder)
        {
            builder
                .ToTable("Post");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Post");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
