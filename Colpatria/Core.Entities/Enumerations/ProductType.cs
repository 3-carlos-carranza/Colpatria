﻿using Crosscutting.Common.Tools.DataType;

namespace Core.Entities.Enumerations
{
    public enum ProductType
    {
        [StringValue("Tarjeta de Credito")]
        [MappingToItemListValue(1)]
        Tc = 1,
        [StringValue("Cuenta de Ahorros")]
        [MappingToItemListValue(2)]
        Ca = 2
    }
}