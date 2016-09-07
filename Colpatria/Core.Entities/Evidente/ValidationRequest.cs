using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    [XmlType("DatosValidacion")]
    public class ValidationRequest
    {
        [XmlElement("FechaExpedicion")]
        public ExpeditionDate ExpeditionDate { get; set; }
        [XmlElement("Identificacion")]
        public Identification Identification { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; } = string.Empty;
    }
}
