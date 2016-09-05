using Application.Main.Definition.Arguments;

namespace Application.Main.Definition.Steps
{
    public interface IStartFlowStep : IStep
    {
        void MakeCustomProcess(IStepArgument stepArgument);
    }
}