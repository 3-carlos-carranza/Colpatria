using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("ScoresMotor")]
    public class ScoresMotor
    {
        [XmlElement(ElementName = "ScoreMotor")]
        public ScoreMotor ScoreMotor { get; set; }
    }
}
