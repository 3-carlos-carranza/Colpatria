using System;
using System.Xml.Serialization;
using Crosscutting.Common;

namespace Core.Entities.Evidente
{
    [XmlType("ExpeditionDate")]
    public class ExpeditionDate
    {
        [XmlAttribute(AttributeName = "timestamp")]
        public long Timestamp { get; set; } = DateTimeExtension.ToTimestamp(DateTime.UtcNow);
    }
}
