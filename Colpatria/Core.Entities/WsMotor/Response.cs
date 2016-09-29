using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Respuesta")]
    public class Response
    {
        [XmlAttribute(AttributeName = "nombre")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "valor")]
        public string Value { get; set; }
    }
}