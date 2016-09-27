using Crosscutting.Common.Tools.DataType;

namespace Presentation.Web.Colpatria.Enumerations
{
    public enum ProductType
    {
        [StringValue("Tarjeta de Credito")]
        [MappingToItemListValue(1)]
        Tc = 1,
        [StringValue("Cuanta de Ahorros")]
        [MappingToItemListValue(2)]
        Ca = 2
    }
}