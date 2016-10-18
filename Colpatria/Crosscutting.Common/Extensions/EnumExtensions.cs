using System;
using System.Reflection;
using Crosscutting.Common.Tools.DataType;

namespace Crosscutting.Common.Extensions
{
    public static class EnumExtension
    {
        public static string GetStringValue(this Enum value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            string output = null;
            var type = value.GetType();

            var fi = type.GetField(value.ToString());
            var attrs = fi?.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (attrs?.Length > 0)
            {
                output = attrs[0].Value;
            }
            return output;
        }

        public static long GetMappingToItemListValue(this Enum value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            long output = 0;
            var type = value.GetType();

            // Check first in our cached results...

            // Look for our 'StringValueAttribute' 

            // in the field's custom attributes
            FieldInfo fi = type.GetField(value.ToString());
            var attrs = fi.GetCustomAttributes(typeof(MappingToItemListValue), false) as MappingToItemListValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }
}
