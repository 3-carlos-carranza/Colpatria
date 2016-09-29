using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Solicitud")]
    public class WsMotorRequest
    {
        [XmlIgnore]
        public long ExecutionId { get; set; }
        [XmlAttribute("tipoIdentificacion")]
        public string TypeIdentification { get; set; }
        [XmlAttribute("identificacion")]
        public string Identification { get; set; }
        [XmlAttribute("primerApellido")]
        public string LastName { get; set; }
        [XmlAttribute("nitUsuario")]
        public string UsertNit { get; set; }
        [XmlAttribute("tipoIdUsuario")]
        public string UserType { get; set; }
        [XmlAttribute("usuario")]
        public string User { get; set; }
        [XmlElement(ElementName = "Parametros")]
        public Parameters Parameters { get; set; }
    }
}