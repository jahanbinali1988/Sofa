using Sofa.CourseManagement.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class AddressConverter
    {
        public static AddressDto Convert(this Address source)
        {
            if (source == null)
            {
                return null;
            }

            return new AddressDto
            {
                City = source.City,
                Country = source.Country,
                State = source.State,
                Street = source.Street,
                ZipCode = source.ZipCode
            };
        }

        public static IEnumerable<AddressDto> Convert(this IEnumerable<Address> source)
        {
            if (source == null)
            {
                return null;
            }

            return source
                .Select(x => Convert(x));
        }

        public static Address Convert(this AddressDto source)
        {
            if (source == null)
            {
                return null;
            }

            return Address.CreateInstance(source.Street, source.City, source.State, source.Country, source.ZipCode);
        }

        public static IEnumerable<Address> Convert(this IEnumerable<AddressDto> source)
        {
            if (source == null)
            {
                return null;
            }

            return source
                .Select(x => Convert(x));
        }
    }
}
