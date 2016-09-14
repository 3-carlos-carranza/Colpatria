#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=StartFlowStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 11:49 a. m.</Update>
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
    public class StartFlowStep : BaseStep, IStartFlowStep
    {
        public StartFlowStep(IProcessFlowStore store) : base(store)
        {
        }
        public string Name => GetType().Name;

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            MakeCustomProcess(argument);
            argument.IsSubmitting = false;
            return await (await OnSucess(argument)).Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public void MakeCustomProcess(IProcessFlowArgument stepArgument)
        {
            
        }
    }
}