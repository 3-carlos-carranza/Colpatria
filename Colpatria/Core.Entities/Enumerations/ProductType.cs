using Crosscutting.Common.Tools.DataType;

namespace Core.Entities.Enumerations
{
    public enum ProductType
    {
        None = 0,

        [StringValue("Tarjeta de Credito")]
        [MappingToItemListValue(1)]
        CreditCard = 1,

        [StringValue("Cuenta de Ahorros")]
        [MappingToItemListValue(2)]
        SavingAccount = 2
    }
}