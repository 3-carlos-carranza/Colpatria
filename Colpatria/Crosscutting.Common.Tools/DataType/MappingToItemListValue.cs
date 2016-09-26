using System;

namespace Crosscutting.Common.Tools.DataType
{
    public class MappingToItemListValue : Attribute
    {
        public MappingToItemListValue(long value)
        {
            Value = value;
        }

        public long Value { get; }
    }
}