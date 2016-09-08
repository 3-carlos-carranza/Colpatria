using System.Threading.Tasks;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Services;
using Application.Main.Definition.Steps;
using Core.GlobalRepository.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitFormStep : BaseStep, IStep
    {
        private readonly ISubmitFormAppService _submitFormService;

        public SubmitFormStep(IExecutionRepository executionRepository, IStepRepository stepRepository,
            IExtendedFieldRepository extendedFieldRepository, ISubmitFormAppService submitFormService)
            : base(executionRepository, stepRepository, extendedFieldRepository)
        {
            _submitFormService = submitFormService;
        }

        public int SectionId { get; set; }
        public int StepId { get; set; }
        public string Name => GetType().Name;

        public async Task<IStepResponse> Advance(IStepArgument stepArgument)
        {
            SetSteps(stepArgument.Steps);

            _submitFormService.SaveForm(stepArgument);

            return await(await OnSuccess(stepArgument.Execution)).Advance(stepArgument);
        }
    }
}