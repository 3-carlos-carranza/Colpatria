using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Parametros")]
    public class Parameters
    {
        [XmlElement(ElementName = "Parametro")]
        public List<Parameter> Parameter { get; set; }
    }
}
