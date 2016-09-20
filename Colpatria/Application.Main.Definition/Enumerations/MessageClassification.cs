using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Definition.Enumerations
{
    public enum MessageClassification
    {
        [StringValue("Aprobada")]
        Approved = 1,
        [StringValue("No Procesada")]
        Unprocessed = 2,
        [StringValue("Pendiente Documentos")]
        PendingDocuments = 3
    }
}