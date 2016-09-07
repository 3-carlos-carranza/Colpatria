using System;
using System.Threading.Tasks;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Steps;
using Core.GlobalRepository.Definition.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class EvidenteStep : BaseStep, IEvidenteStep
    {
        public EvidenteStep(IExecutionRepository executionRepository, 
            IStepRepository stepRepository,
            IExtendedFieldRepository extendedFieldRepository) 
            : base(executionRepository, stepRepository, extendedFieldRepository)
        {
        }
        public int SectionId { get; set; }
        public int StepId { get; set; }
        public string Name => GetType().Name;
        public Task<IStepResponse> Advance(IStepArgument stepArgument)
        {
            throw new NotImplementedException();
        }
    }
}