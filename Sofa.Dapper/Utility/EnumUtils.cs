using System;
using System.ComponentModel;
using System.Linq;

namespace Sofa.Dapper.Utility
{
    public static class EnumUtils
    {
        public static string GetDescription(this Enum value)
        {
            var descriptionAttribute = (DescriptionAttribute)value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .Where(a => a is DescriptionAttribute)
                .FirstOrDefault();

            return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
        }
    }
}
