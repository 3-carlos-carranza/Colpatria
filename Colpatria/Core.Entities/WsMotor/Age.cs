using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Edad")]
    public class Age
    {
        [XmlAttribute(AttributeName = "min")]
        public string Min { get; set; }
        [XmlAttribute(AttributeName = "max")]
        public string Max { get; set; }
    }
}
