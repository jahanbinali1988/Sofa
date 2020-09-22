using Sofa.SharedKernel.BaseClasses.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.Model
{
    public class Address : ValueObject<Address>
    {
        public String Street { get; private set; }
        public String City { get; private set; }
        public String State { get; private set; }
        public String Country { get; private set; }
        public String ZipCode { get; private set; }

        internal Address() { }

        public static Address CreateInstance(string street, string city, string state, string country, string zipcode)
        {
            return new Address()
            {
                Street = street,
                City = city,
                State = state,
                Country = country,
                ZipCode = zipcode
            };
        }
    }
}
