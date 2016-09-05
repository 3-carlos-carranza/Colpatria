using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Steps;

namespace Application.Main.Definition
{
    public interface IProcessFlowService
    {
        IEnumerable<IStep> Steps { get; }
        Task<IStepResponse> RunFlow(IProcessFlowArgument processFlowArgument);
    }
}