//   -----------------------------------------------------------------------
//   <copyright file=IProcessAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

#region

using System.Collections.Generic;
using Core.DataTransferObject.Vib;
using Core.Entities.Process;

#endregion

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IProcessAppService
    {
        IEnumerable<Step> GetAllStepsEnablesByProduct(long productId);
        StepDetail GetCurrentStepDetailByExecutionId(long executionId);
        StepDetail GetNextStepWithType(int step, int section, int processId, int type);
        void UpdateExecution(Execution execution);
    }
}