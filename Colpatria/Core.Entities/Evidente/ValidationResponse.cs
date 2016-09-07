using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    [XmlType("RespValidacion")]
    public class ValidationResponse
    {
        [XmlAttribute(AttributeName = "alertas")]
        public bool Alerts { get; set; }
        public bool Success => ProcessResult && (Result == 5 || Result == 1);
        [XmlAttribute(AttributeName = "excluirCliente")]
        public bool ExcludeClient { get; set; }
        [XmlAttribute(AttributeName = "numIntentos")]
        public int NumberOfIntents { get; set; }
        [XmlAttribute(AttributeName = "resultadoProceso")]
        public bool ProcessResult { get; set; }
        [XmlAttribute(AttributeName = "resultado")]
        public int Result { get; set; }
        [XmlAttribute(AttributeName = "valFechaExp")]
        public bool ValidatedExpeditionDate { get; set; }
        [XmlAttribute(AttributeName = "valApellido")]
        public bool ValidatedLastname { get; set; }
        [XmlAttribute(AttributeName = "valNombre")]
        public bool ValidatedName { get; set; }
        [XmlAttribute(AttributeName = "regValidacion")]
        public long ValidationNumber { get; set; }
    }
}
