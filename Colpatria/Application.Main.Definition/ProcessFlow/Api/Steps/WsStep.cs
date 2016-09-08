#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=WsStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 10:16 a. m.</Date>
//   <Update> 2016-09-08 - 11:43 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.Handler;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps.Responses;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.Steps
{
    public abstract class WsStep : BaseStep
    {
        private readonly IProcessFlowStore _store;
        private readonly IHandler _wsHandler;

        protected WsStep(IHandler handler, IProcessFlowStore store) : base(store)
        {
            _wsHandler = handler;
            _store = store;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            // Instantiate the delegate.
            TraceFlow(argument);
            Console.WriteLine("Advance Step " + Name);
            Console.WriteLine("Getting web default service... ");
            var response = _wsHandler.Send(argument);

            return await (await OnSucess(argument)).Advance(argument);
        }

        public override async Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            TraceFlow(argument);
            Console.WriteLine("Advance Step " + Name);
            Console.WriteLine("Getting web service... ");
            var response = _wsHandler.Send(argument);
            return
                await
                    Task.Run(() => new ProcessFlowResponse() as IProcessFlowResponse, cancellationToken)
                        .ConfigureAwait(false);
        }
    }
}