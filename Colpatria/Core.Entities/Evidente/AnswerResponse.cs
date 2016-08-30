using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    [XmlType("Evaluacion")]
    public class AnswerResponse
    {
        [XmlAttribute("preguntasCompletas")]
        public bool AnsweredCompletely { get; set; }

        [XmlAttribute("aprobacion")]
        public bool Approval { get; set; }

        [XmlAttribute("resultado")]
        public bool Result { get; set; }

        [XmlAttribute("score")]
        public int Score { get; set; }

        [XmlAttribute("aprobado100PorCientoOK")]
        public bool SecondApproval { get; set; }

        [XmlAttribute("codigoSeguridad")]
        public string SecurityCode { get; set; }
    }
}
