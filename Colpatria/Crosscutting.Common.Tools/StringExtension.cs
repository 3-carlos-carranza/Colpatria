using System;
using System.ComponentModel;
using System.Globalization;

namespace Crosscutting.Common.Tools
{
    public static class StringExtension
    {
        public static object ChangeType(this object value, Type conversionType)
        {
            if (conversionType == null)
            {
                throw new ArgumentNullException(nameof(conversionType));
            }
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                if (value == null)
                {
                    return null;
                }
                var nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType, CultureInfo.CurrentCulture);
        }
    }
}