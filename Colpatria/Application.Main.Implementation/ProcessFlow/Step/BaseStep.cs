using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Steps;
using Core.Entities.SQL.Enumerations;
using Core.Entities.SQL.Process;
using Core.GlobalRepository.Definition.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class BaseStep
    {
        private readonly IExecutionRepository _executionRepository;
        private readonly IExtendedFieldRepository _extendedFieldRepository;
        private readonly IStepRepository _stepRepository;
        private IStep _stepOnError;
        private IStep _stepOnFailed;
        private IStep _stepOnSuccess;
        private IEnumerable<IStep> _steps;
        protected string LocalName;

        public BaseStep(IExecutionRepository executionRepository, IStepRepository stepRepository,
            IExtendedFieldRepository extendedFieldRepository)
        {
            _executionRepository = executionRepository;
            _stepRepository = stepRepository;
            _extendedFieldRepository = extendedFieldRepository;
        }

        public void SetSteps(IEnumerable<IStep> steps) => _steps = steps;

        public IStepResponse ValidateNextStep(Execution execution, StepType stepType)
        {
            return null;
        }

        protected Task<IStep> OnError(Execution execution)
        {
            return Task.FromResult(_stepOnError);
        }

        protected Task<IStep> OnSuccess(Execution execution)
        {
            return Task.FromResult(_stepOnSuccess);
        }

        protected Task<IStep> OnFailed(Execution execution)
        {
            return Task.FromResult(_stepOnFailed);
        }
    }
}