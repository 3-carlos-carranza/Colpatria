using System;
using System.Reflection;
using Crosscutting.Common.Tools.DataType;

namespace Crosscutting.Common
{
    public static class EnumExtension
    {
        public static string GetStringValue(this Enum value)
        {
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
    }
}
