using Application.Main.Definition.Arguments;
using Core.DataTransferObject.SQL;

namespace Application.Main.Implementation.ProcessFlow
{
    public class ProcessFlowArgument : IProcessFlowArgument
    {
        public ExecutionArgument ExecutionArgument { get; set; }
        public StepArgument StepArgument { get; set; }
        public bool IsSubmitting { get; set; }
    }
}