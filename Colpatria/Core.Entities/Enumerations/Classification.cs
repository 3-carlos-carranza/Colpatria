using Crosscutting.Common.Tools.DataType;

namespace Core.Entities.Enumerations
{
    public enum Classification
    {
        [StringValue("Aprobada")]
        Approved = 1,
        [StringValue("Rechazada")]
        Declined = 2
    }
}