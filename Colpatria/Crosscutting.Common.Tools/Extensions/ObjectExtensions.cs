using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Crosscutting.Common.Tools.Contracts;

namespace Crosscutting.Common.Tools.Extensions
{
    public static class ObjectExtensions
    {
        public static object ChangeType(this object value, Type conversionType)
        {
            if (conversionType == null) throw new ArgumentNullException(nameof(conversionType));
            if (conversionType == null)
            {
                throw new ArgumentNullException(nameof(conversionType));
            }
            if (!conversionType.IsGenericType || conversionType.GetGenericTypeDefinition() != typeof(Nullable<>))
                return Convert.ChangeType(value, conversionType, CultureInfo.CurrentCulture);
            if (value == null)
            {
                return null;
            }
            var nullableConverter = new NullableConverter(conversionType);
            conversionType = nullableConverter.UnderlyingType;
            return Convert.ChangeType(value, conversionType, CultureInfo.CurrentCulture);
        }

        public static T MapDictionaryToObject<T>(T obj, IEnumerable<FieldValueType> fieldValueTypes)
                    where T:class 
        {
            var valueTypes = fieldValueTypes as IList<FieldValueType> ?? fieldValueTypes.ToList();
            IEnumerable<string> names = valueTypes.Select(s => s.Key).Distinct().ToList();
            var propertiesmach = obj.GetType().GetProperties().ToList().Where(s => names.Contains(s.Name));
            foreach (var info in propertiesmach)
            {
                var item = valueTypes.FirstOrDefault(s => s.Key == info.Name);
                if (item == null) continue;
                if (info.CanWrite)
                {
                    info.SetValue(obj, item.Value.ChangeType(info.PropertyType), null);
                }
                //obj.GetType().GetProperty(info.Name).SetValue(info.Name, item.Value, null);
            }

            return obj;
        }
    }
}