using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("razon")]
    public class Reason
    {
        [XmlAttribute("codigo")]
        public string Code { get; set; }
    }
}