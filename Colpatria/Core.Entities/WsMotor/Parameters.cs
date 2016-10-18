using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Entities.WsMotor
{
    [XmlType("Parametros")]
    public class Parameters
    {
        private readonly List<Parameter> _parameters;

        public Parameters()
        {
            _parameters = new List<Parameter>();
        }

        public Parameters(IEnumerable<Parameter> parameters)
        {
            _parameters = new List<Parameter>();
            _parameters.AddRange(parameters);
        }

        [XmlElement(ElementName = "Parametro")]
        public IList<Parameter> Parameter => _parameters;
    }
}