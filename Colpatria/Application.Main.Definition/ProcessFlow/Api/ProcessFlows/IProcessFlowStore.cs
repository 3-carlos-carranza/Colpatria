#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IProcessFlowStore.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 10:09 a. m.</Date>
//   <Update> 2016-09-09 - 12:51 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities.ProcessModel;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.ProcessFlows
{
    public interface IProcessFlowStore
    {
        IEnumerable<StepFlow> Steps { get; }

        void TrackingStep(IProcessFlowArgument argument);

        StepFlow GetNextStep(IProcessFlowArgument argument, StepType stepType);

        StepFlow StepDetail(IProcessFlowArgument argument);
        void SetNextStep(IProcessFlowArgument argument,StepType stepType);
        StepFlow GetCurrentStep(IProcessFlowArgument argument);

        Task<StepFlow> GetNextStepAsync(IProcessFlowArgument argument, StepType stepType,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}