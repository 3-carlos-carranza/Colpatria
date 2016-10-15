using System;
using System.Xml.Serialization;
using Crosscutting.Common.Extensions;

namespace Core.Entities.Evidente
{
    [XmlType("ExpeditionDate")]
    public class ExpeditionDate
    {
        [XmlAttribute(AttributeName = "timestamp")]
        public long Timestamp { get; set; } = DateTime.UtcNow.ToTimestamp();
    }
}
