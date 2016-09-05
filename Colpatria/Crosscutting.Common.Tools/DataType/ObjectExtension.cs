using System.Collections.Generic;
using System.Linq;

namespace Crosscutting.Common.Tools.DataType
{
    public static class ObjectExtension<T> where T : class
    {
        public static T MapDictinaryToObject(T obj, IEnumerable<FieldValueType> fieldValueTypes)
        {
            IEnumerable<string> names = fieldValueTypes.Select(s => s.Key).Distinct().ToList();
            var propertiesmach = obj.GetType().GetProperties().ToList().Where(s => names.Contains(s.Name));
            foreach (var info in propertiesmach)
            {
                var item = fieldValueTypes.FirstOrDefault(s => s.Key == info.Name);
                if (item != null)
                {
                    if (info != null && info.CanWrite)
                    {
                        info.SetValue(obj, item.Value.ChangeType(info.PropertyType), null);
                    }
                    //obj.GetType().GetProperty(info.Name).SetValue(info.Name, item.Value, null);
                }
            }

            return obj;
        }
    }
}