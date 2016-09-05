using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crosscutting.Common.Tools.DataType;

namespace Crosscutting.Common.Tools.Web
{
    public static class WebExtension
    {
        public static byte[] HasBytes(this FormCollection collection, string key, HttpFileCollectionBase files)
        {
            var file = files[key];
            if (file == null) return null;
            using (var inputStream = file.InputStream)
            {
                var memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                var data = memoryStream.ToArray();
                return data;
            }
        }

        public static List<FieldValueOrder> ToFieldValueOrder(this FormCollection collection)
        {
            var list = new List<FieldValueOrder>();
            var counter = 0;
            foreach (var key in collection.AllKeys.Distinct())
            {
                var keyint = 0;
                var lastkey = "";
                var field = new FieldValueOrder();
                var order = 1;
                var applicant = 1;
                if (key.Contains("_"))
                {
                    var splitvalues = key.Split('_');
                    //only applicant
                    if (splitvalues.Count() - 1 == 1)
                    {
                        lastkey = splitvalues.First();
                        int.TryParse(splitvalues.Last(), out applicant);
                    }
                    // applicant & order
                    if (splitvalues.Count() - 1 == 2)
                    {
                        lastkey = splitvalues.First();
                        int.TryParse(splitvalues[1], out applicant);
                        int.TryParse(splitvalues.Last(), out order);
                    }
                }
                else
                {
                    lastkey = key;
                }
                if (!int.TryParse(lastkey, out keyint))
                {
                    counter++;
                    continue;
                }

                field.Applicant = applicant;
                field.Order = order;
                field.Key = lastkey;
                field.Value = collection[counter];
                list.Add(field);
                counter++;
            }
            return list;
        }

        public static FormCollection RemoveUnnecessaryAndEmptyFields(this FormCollection collection)
        {
            var list = new FormCollection();
            var counter = 0;
            foreach (var key in collection.AllKeys.Distinct())
            {
                var value = collection.Get(key);
                if (!string.IsNullOrEmpty(value))
                {
                    list.Add(key, collection.Get(key));
                }
                counter++;
            }
            return list;
        }

        public static List<FieldValueOrder> ToFieldValueOrder(this HttpFileCollectionBase files)
        {
            var list = new List<FieldValueOrder>();
            var counter = 0;
            foreach (var key in files.AllKeys.Distinct())
            {
                var fieldfile = files[key];
                var keyint = 0;
                var lastkey = "";
                var field = new FieldValueOrder();
                var order = 1;
                var applicant = 1;
                if (key.Contains("_"))
                {
                    var splitvalues = key.Split('_');
                    //only applicant
                    if (splitvalues.Count() - 1 == 1)
                    {
                        lastkey = splitvalues.First();
                        int.TryParse(splitvalues.Last(), out applicant);
                    }
                    // applicant & order
                    if (splitvalues.Count() - 1 == 2)
                    {
                        lastkey = splitvalues.First();
                        int.TryParse(splitvalues[1], out applicant);
                        int.TryParse(splitvalues.Last(), out order);
                    }
                }
                else
                {
                    lastkey = key;
                }
                if (!int.TryParse(lastkey, out keyint))
                {
                    counter++;
                    continue;
                }
                if (fieldfile == null) continue;
                using (var inputStream = fieldfile.InputStream)
                {
                    var memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    var data = memoryStream.ToArray();
                    field.Applicant = applicant;
                    field.Order = order;
                    field.Key = lastkey;
                    field.Bytes = data;
                    field.Value = fieldfile.FileName;
                    list.Add(field);
                }
                counter++;
            }
            return list;
        }

        public static Dictionary<string, string> ToDictionary(this FormCollection collection)
        {
            return collection.AllKeys.ToDictionary(k => k, k => collection[k].Split(',')[0]);
        }

        public static List<FieldValueOrder> RemoveEmptyFields(this List<FieldValueOrder> collection)
        {
            return collection.Where(s => s.Key != "" && !string.IsNullOrEmpty(s.Key)).ToList();
        }
    }
}