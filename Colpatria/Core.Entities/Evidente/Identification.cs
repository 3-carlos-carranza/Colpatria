using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    [XmlType("Identificacion")]
    public class Identification
    {
        [XmlAttribute(AttributeName = "numero")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "tipo")]
        public string Type { get; set; }
    }
}
