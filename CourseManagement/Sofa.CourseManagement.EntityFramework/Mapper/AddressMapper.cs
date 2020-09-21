using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Map;

namespace Sofa.CourseManagement.EntityFramework.Mapper
{
    public class AddressMapper : BaseEntityMap<Address>
    {
        public override void Map(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey("ZipCode","x.InstituteId")
                .HasName("PK_Address");

            builder
                .ToTable("Address");
        }
    }
}
