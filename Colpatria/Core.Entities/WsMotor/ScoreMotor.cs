using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("ScoreMotor")]
    public class ScoreMotor
    {
        [XmlAttribute(AttributeName = "tipo")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "puntaje")]
        public string Score { get; set; }
        [XmlAttribute(AttributeName = "clasificacion")]
        public string Classification { get; set; }
    }
}
