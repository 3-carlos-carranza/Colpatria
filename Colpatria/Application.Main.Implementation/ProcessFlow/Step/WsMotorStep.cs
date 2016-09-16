//   -----------------------------------------------------------------------
//   <copyright file=WsMotorStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class WsMotorStep : BaseStep
    {
        public WsMotorStep(IProcessFlowStore store) : base(store)
        {
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            return await OnSuccess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}