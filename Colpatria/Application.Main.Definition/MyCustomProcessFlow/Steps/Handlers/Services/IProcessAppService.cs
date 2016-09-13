#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IProcessAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 3:10 p. m.</Date>
//   <Update> 2016-09-08 - 3:14 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Core.DataTransferObject.Vib;
using Core.Entities.Enumerations;
using Core.Entities.Process;
using Core.Entities.ProcessModel;

#endregion

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IProcessAppService
    {
        IEnumerable<Step> GetAllStepsEnablesByProduct(long productId);
        StepDetail GetCurrentStepDetailByExecutionId(long executionId);
        StepDetail GetNextStepWithType(int step, int section, int processId, StepType type);
        void UpdateExecution(Execution execution);

    }
}