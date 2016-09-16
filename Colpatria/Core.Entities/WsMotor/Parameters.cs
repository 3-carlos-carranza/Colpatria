using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Parametros")]
    public class Parameters
    {
        [XmlAttribute("tipo")]
        public char Type { get; set; }

        [XmlAttribute("nombre")]
        public string Name { get; set; }

        [XmlAttribute("valor")]
        public string Value { get; set; }
    }
}