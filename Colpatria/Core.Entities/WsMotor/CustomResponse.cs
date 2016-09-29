using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("RespuestaPersonalizadaMotor")]
    public class CustomResponse
    {
        [XmlElement(ElementName = "Respuesta")]
        public List<Response> Response { get; set; }
    }
}