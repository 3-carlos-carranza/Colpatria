using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    [XmlType("Respuesta")]
    public class OptionsAnswer
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "texto")]
        public string Text { get; set; }
    }
}
