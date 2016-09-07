using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.Evidente
{
    [XmlType("Pregunta")]
    public class Question
    {
        [XmlAttribute(AttributeName = "idRespuestaCorrecta")]
        public string CorrectAnswerId { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "orden")]
        public int Order { get; set; }

        [XmlAttribute(AttributeName = "texto")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "peso")]
        public int Weight { get; set; }

        [XmlElement(ElementName = "Respuesta")]
        public List<Answer> Answers { get; set; }
    }
}
