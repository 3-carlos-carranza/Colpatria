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
        [XmlElement(ElementName = "codError")]
        public string CodeError { get; set; }
        [XmlElement(ElementName = "descError")]
        public string DescriptionError { get; set; }
        [XmlElement(ElementName = "NaturalNacional")]
        public NaturalPerson NaturalPerson { get; set; }
        [XmlElement(ElementName = "ScoresMotor")]
        public ScoresMotor ScoresMotor { get; set; }
        [XmlElement(ElementName = "RespuestaPersonalizadaMotor")]
        public CustomResponse CustomResponse { get; set; }
    }
}