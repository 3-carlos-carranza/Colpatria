using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("NaturalNacional")]
    public class NaturalPerson
    {
        [XmlAttribute(AttributeName = "nombres")]
        public string Names { get; set; }
        [XmlAttribute(AttributeName = "primerApellido")]
        public string LastName { get; set; }
        [XmlAttribute(AttributeName = "segundoApellido")]
        public string SecondLastName { get; set; }
        [XmlAttribute(AttributeName = "nombreCompleto")]
        public string FullName { get; set; }
        [XmlAttribute(AttributeName = "validada")]
        public string Validated { get; set; }
        [XmlAttribute(AttributeName = "rut")]
        public string Rut { get; set; }
        [XmlElement(ElementName = "Identificacion")]
        public Identification Identification { get; set; }
        [XmlElement(ElementName = "Edad")]
        public Age Age { get; set; }
    }
}
