using System;
using System.Linq;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Extensions;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class CustomActionAppService : ICustomActionAppService
    {
        private readonly IExecutionRepository _executionRepository;
        private readonly IStepSectionRepository _stepSectionRepository;

        public CustomActionAppService(IStepSectionRepository stepSectionRepository,
            IExecutionRepository executionRepository)
        {
            _stepSectionRepository = stepSectionRepository;
            _executionRepository = executionRepository;
        }

        public void GoToStep<T>(T enumerador, long requestId) where T : struct, IComparable, IFormattable, IConvertible
        {
            var @enum = enumerador as Enum;
            var sectionid = @enum != null ? (int) @enum.GetMappingToItemListValue() : 0;
            //var sectionid =  @enum.;
            var stepSection = _stepSectionRepository.Get(s => s.SectionId == sectionid);
            var execution = _executionRepository.GetFiltered(s => s.Id == requestId).FirstOrDefault();

            if (execution != null)
            {
                execution.CurrentSectionId = sectionid;
                execution.CurrentStepId = stepSection.StepId;
                _executionRepository.Update(execution);
            }
            _executionRepository.UnitOfWork.Commit();
        }
    }
}