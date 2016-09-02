using System.Threading.Tasks;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;

namespace Application.Main.Definition.Steps
{
    public interface IStep
    {
        int SectionId { get; set; }
        int StepId { get; set; }
        string Name { get; }
        Task<IStepResponse> Advance(IStepArgument stepArgument);

        //void TraceFlow(TraceFlowSettings traceFlowSettings);
    }
}