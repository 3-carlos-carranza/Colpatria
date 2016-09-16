using System.Collections.Generic;
using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Definition.ProcessFlow.Api.ProcessFlows
{
    public interface ISubmitFormArgument : IProcessFlowArgument
    {
        IList<FieldValueOrder> Form { get; set; }
    }
}
