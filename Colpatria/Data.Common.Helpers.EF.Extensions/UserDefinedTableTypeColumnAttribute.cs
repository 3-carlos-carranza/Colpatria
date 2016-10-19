using System;

namespace Data.Common.Helpers.EF.Extensions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UserDefinedTableTypeColumnAttribute : Attribute
    {
        public UserDefinedTableTypeColumnAttribute(int order)
        {
            Order = order;
        }

        public UserDefinedTableTypeColumnAttribute(int order, string name)
        {
            Order = order;
            Name = name;
        }

        public int Order { get; set; }

        public string Name { get; set; }
    }
}