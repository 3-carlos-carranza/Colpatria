using System.Collections.Generic;
using Core.Entities.ProcessModel;

namespace Application.Main.Definition.ProcessFlow.Api.ProcessFlows
{
    public interface IProcessFlowArgument
    {
        Execution Execution { get; set; }

        IProcessFlowUser User { get; set; }

        bool IsSubmitting { get; set; }

        IEnumerable<IStep> Steps { get; set; }
    }
}