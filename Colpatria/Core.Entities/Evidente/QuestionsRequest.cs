using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    public class QuestionsRequest
    {
        [XmlAttribute(AttributeName = "identificacion")]
        public string Identification { get; set; }
        [XmlAttribute(AttributeName = "tipoId")]
        public string IdentificationType { get; set; }
        [XmlAttribute(AttributeName = "regValidacion")]
        public long ValidationNumber { get; set; }
    }
}
