using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("RespuestaMotor")]
    public class WsMotorServiceResponse
    {
        [XmlAttribute(AttributeName = "idEstrategia")]
        public string StrategyId { get; set; }
        [XmlAttribute(AttributeName = "idPrograma")]
        public string ProgramId { get; set; }
        [XmlAttribute(AttributeName = "idMotor")]
        public string MotorId { get; set; }
        [XmlAttribute(AttributeName = "fechaConsulta")]
        public string ConsultationDate { get; set; }
        [XmlElement(ElementName = "NaturalNacional")]
        public NaturalPerson NaturalPerson { get; set; }
        [XmlElement(ElementName = "ScoresMotor")]
        public ScoresMotor ScoresMotor { get; set; }
        [XmlElement(ElementName = "RespuestaPersonalizadaMotor")]
        public CustomResponse CustomResponse { get; set; }
    }
}