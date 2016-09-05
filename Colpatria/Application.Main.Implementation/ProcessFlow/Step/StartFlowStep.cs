using System;
using System.Threading.Tasks;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Steps;
using Core.Entities.SQL.Enumerations;
using Core.GlobalRepository.Definition.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class StartFlowStep : BaseStep, IStartFlowStep
    {
        public StartFlowStep(IExecutionRepository executionRepository, IStepRepository stepRepository,
            IExtendedFieldRepository extendedFieldRepository)
            : base(executionRepository, stepRepository, extendedFieldRepository)
        {
        }

        public int SectionId { get; set; }
        public int StepId { get; set; }
        public string Name => GetType().Name;

        public async Task<IStepResponse> Advance(IStepArgument stepArgument)
        {
            SetSteps(stepArgument.Steps);

            MakeCustomProcess(stepArgument);

            return ValidateNextStep(stepArgument.Execution, StepType.OnSuccess) ??
                   await (await OnSuccess(stepArgument.Execution)).Advance(stepArgument);
        }

        public void MakeCustomProcess(IStepArgument stepArgument)
        {
            throw new NotImplementedException();
        }
    }
}