using System.Collections.Generic;
using Crosscutting.Common.Tools.DataType;

namespace Core.DataTransferObject.Vib
{
    public class ExecutionArgument
    {
        public bool AutoAdvance { get; set; }
        public List<FieldValueOrder> Collection { get; set; }
        public string UserName { get; set; }
        public int? SectionId { get; set; }
        public int? PageId { get; set; }
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public bool IsPost { get; set; }
    }
}