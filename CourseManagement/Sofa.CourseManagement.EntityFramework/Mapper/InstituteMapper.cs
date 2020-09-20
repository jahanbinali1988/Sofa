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
            builder
                .HasKey(x => x.Id)
                .HasName("PK_Institute");

            builder
                .ToTable("Institute").OwnsMany<Address>(e => e.Addresses, a =>
                {
                    a.WithOwner();
                    //.HasForeignKey(d => d.InstituteId)
                    //.HasPrincipalKey(k => k.Id);
                });
        }
    }
}
