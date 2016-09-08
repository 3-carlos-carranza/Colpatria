#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=EvidenteStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 3:26 p. m.</Date>
//   <Update> 2016-09-08 - 11:46 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class EvidenteStep : BaseStep, IEvidenteStep
    {
        public EvidenteStep(IProcessFlowStore store) : base(store)
        {
        }

        public int SectionId { get; set; }
        public int StepId { get; set; }
        public string Name => GetType().Name;

        public override Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            throw new NotImplementedException("falta la Implementación para el paso del servicio EVIDENTE");
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}