using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("score")]
    public class ScoreResponse
    {
        [XmlAttribute(AttributeName = "tipo")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "puntaje")]
        public string Score { get; set; }
        
        [XmlAttribute(AttributeName = "clasificacion")]
        public string Classification { get; set; }

        [XmlAttribute(AttributeName = "razon")]
        public IEnumerable<Reason> Reason { get; set; }
    }
}