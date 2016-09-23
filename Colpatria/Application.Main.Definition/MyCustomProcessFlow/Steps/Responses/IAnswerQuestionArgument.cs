using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Core.Entities.Evidente;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IAnswerQuestionArgument : IProcessFlowArgument
    {
        AnswerRequest AnswerRequest { get; set; }
    }
}
