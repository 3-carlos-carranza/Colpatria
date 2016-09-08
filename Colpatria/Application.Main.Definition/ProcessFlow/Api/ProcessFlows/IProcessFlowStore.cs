#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IProcessFlowStore.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-05  - 4:09 p. m.</Date>
//   <Update> 2016-09-06 - 3:48 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Threading;
using System.Threading.Tasks;
using Core.Entities.ProcessModel;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.ProcessFlows
{
    public interface IProcessFlowStore
    {
        void TrackingStep(IProcessFlowArgument argument);

        Task<Step> GetNextStep(IProcessFlowArgument argument, StepType stepType);
        Task<Step> GetCurrentStep(IProcessFlowArgument argument);
        Task<Step> GetNextStepAsync(IProcessFlowArgument argument, StepType stepType,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}