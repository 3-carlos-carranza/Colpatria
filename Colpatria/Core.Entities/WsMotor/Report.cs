using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("informe")]
    public class Report
    {
        [XmlElement("linea")]
        public Line Line { get; set; }
    }
}