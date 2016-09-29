using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Parametro")]
    public class Parameter
    {
        [XmlAttribute("tipo")]
        public string Type { get; set; }
        [XmlAttribute("nombre")]
        public string Name { get; set; }
        [XmlAttribute("valor")]
        public string Value { get; set; }
    }
}