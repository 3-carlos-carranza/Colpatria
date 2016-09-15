using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Solicitud")]
    public class Petition
    {
        [XmlAttribute("clave")]
        public string Key { get; set; }

        [XmlAttribute("identificación")]
        public string Identification { get; set; }

        [XmlAttribute("primerApellido")]
        public string LastName { get; set; }

        [XmlAttribute("producto")]
        public string Product => "64";

        [XmlAttribute("tipoIdentificacion")]
        public string TypeIdentification { get; set; }

        [XmlAttribute("usuario")]
        public string User { get; set; }

        [XmlAttribute("Parametros")]
        public IEnumerable<Parameters> ParamsRequest { get; set; }
    }
}