#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ProcessAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 3:11 p. m.</Date>
//   <Update> 2016-09-13 - 11:16 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.DataTransferObject.Vib;
using Core.Entities.Enumerations;
using Core.Entities.Process;
using Core.Entities.ProcessModel;
using Core.GlobalRepository.SQL.Process;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class ProcessAppService : IProcessAppService
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IStepRepository _stepRepository;
        private readonly IExecutionRepository _executionRepository;

        public ProcessAppService(IStepRepository stepRepository, ISectionRepository sectionRepository, IExecutionRepository executionRepository)
        {
            _stepRepository = stepRepository;
            _sectionRepository = sectionRepository;
            _executionRepository = executionRepository;
        }

        public IEnumerable<Core.Entities.Process.Step> GetAllStepsEnablesByProduct(long productId)
        {
            return _stepRepository.GetAllStepsEnablesByProduct(productId);
        }

        public StepDetail GetNextStepWithType(int step, int section, int processId, StepType type)
        {
            return _executionRepository.GetNextStepWithType(step, section, processId,type);
        }

        public void UpdateExecution(Execution execution)
        {
            _executionRepository.Update(execution);
            _executionRepository.UnitOfWork.Commit();
        }

        public StepDetail GetCurrentStepDetailByExecutionId(long executionId)
        {
            return _sectionRepository.GetCurrentStepDetailByExecutionId(executionId);
        }
    }
}