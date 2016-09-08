using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    [XmlType("Respuestas")]
    public class AnswerRequest
    {
        [XmlElement("Respuesta")]
        public List<OptionsAnswer> Answers { get; set; }
        [XmlElement("Identificacion")]
        public Identification Identification { get; set; }
        [XmlAttribute("idCuestionario")]
        public string QuestionsId { get; set; }
        [XmlAttribute("regCuestionario")]
        public string Record { get; set; }
    }
}
