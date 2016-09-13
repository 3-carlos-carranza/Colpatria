using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    public class QuestionsResponse
    {
        [XmlAttribute(AttributeName = "codigoAlerta")]
        public string AlertCode { get; set; }
        [XmlAttribute(AttributeName = "respuestaAlerta")]
        public string AlertResponse { get; set; }
        [XmlAttribute(AttributeName = "alertas")]
        public string Alerts { get; set; }
        [XmlAttribute(AttributeName = "numeroIntentosAno")]
        public int AnnualNumberOfIntents { get; set; }
        [XmlAttribute(AttributeName = "numeroIntentosDia")]
        public int DailyNumberOfIntents { get; set; }
        [XmlAttribute(AttributeName = "excluirCliente")]
        public bool ExcludeClient { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "numeroIntentosMes")]
        public int MonthlyNumberOfIntents { get; set; }
        [XmlElement(ElementName = "Pregunta")]
        public List<Question> Questions { get; set; }
        [XmlAttribute(AttributeName = "registro")]
        public string Record { get; set; }
        [XmlAttribute(AttributeName = "resultado")]
        public string Result { get; set; }
        [XmlAttribute(AttributeName = "subTipGenCuestionario")]
        public string Subtip { get; set; }
        public bool MaximumAttemptsPerDay => Result.Equals("10");
        public bool MaximumAttemptsPerMonth => Result.Equals("11");
        public bool MaximumAttemptsPerYear => Result.Equals("12");
        public bool Success => Result.Equals("01");
    }
}
