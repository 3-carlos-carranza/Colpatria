using Core.DataTransferObject.SQL;

namespace Application.Main.Definition.Arguments
{
    public interface IProcessFlowArgument
    {
        ExecutionArgument ExecutionArgument { get; set; }
        IStepArgument StepArgument { get; set; }
        bool IsSubmitting { get; set; }
    }
}