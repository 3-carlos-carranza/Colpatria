using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    [XmlType("Respuesta")]
    public class Answer
    {
        [XmlAttribute("idRespuesta")]
        public string AnswerId { get; set; }
        [XmlAttribute("idPregunta")]
        public string QuestionId { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "texto")]
        public string Text { get; set; }
    }
}
