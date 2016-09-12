using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    public class SelectAnswer
    {
        [XmlAttribute("idRespuesta")]
        public string AnswerId { get; set; }

        [XmlAttribute("idPregunta")]
        public string QuestionId { get; set; }
    }
}
