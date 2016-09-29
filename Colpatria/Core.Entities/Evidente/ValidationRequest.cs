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
        [XmlElement("Nombres")]
        public string Names { get; set; }
        [XmlElement("PrimerApellido")]
        public string LastName { get; set; }
        [XmlElement("SegundoApellido")]
        public string SecondLastName { get; set; } = string.Empty;
    }
}
