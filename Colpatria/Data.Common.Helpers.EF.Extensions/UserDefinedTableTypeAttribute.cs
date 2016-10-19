using System;

namespace Data.Common.Helpers.EF.Extensions
{
    public class UserDefinedTableTypeAttribute : Attribute
    {
        public UserDefinedTableTypeAttribute(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Cannot be null or empty.", nameof(name));

            Name = name;
        }

        public string Name { get; set; }
    }
}