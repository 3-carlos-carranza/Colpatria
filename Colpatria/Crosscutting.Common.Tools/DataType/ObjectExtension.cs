using System.Collections.Generic;
using System.Linq;

namespace Crosscutting.Common.Tools.DataType
{
    public static class ObjectExtension
    {
        public static T MapDictinaryToObject<T>(T obj, IEnumerable<FieldValueType> fieldValueTypes)
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