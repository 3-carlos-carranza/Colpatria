using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("score")]
    public class ScoreResponse
    {
        [XmlAttribute("tipo")]
        public string Type { get; set; }

        [XmlAttribute("puntaje")]
        public string Score { get; set; }

        [XmlAttribute("clasificacion")]
        public string Classification { get; set; }

        [XmlAttribute("razon")]
        public IEnumerable<Reason> Reason { get; set; }
    }
}