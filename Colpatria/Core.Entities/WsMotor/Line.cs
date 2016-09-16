using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("linea")]
    public class Line
    {
        [XmlAttribute(AttributeName = "consecutivo")]
        public string Consecutive { get; set; }
    }
}