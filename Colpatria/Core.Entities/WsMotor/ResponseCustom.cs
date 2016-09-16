using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("repuestaPersonalizada")]
    public class ResponseCustom
    {
        [XmlElement("informe")]
        public Report Report { get; set; }
    }
}