using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Identificacion")]
    public class Identification
    {
        [XmlAttribute(AttributeName = "numero")]
        public string Number { get; set; }
    }
}
