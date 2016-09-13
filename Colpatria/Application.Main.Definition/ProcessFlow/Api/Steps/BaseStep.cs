#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=BaseStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-05  - 4:09 p. m.</Date>
//   <Update> 2016-09-06 - 5:01 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.Steps
{
    public abstract class BaseStep : IStep
    {
        private readonly IProcessFlowStore _store;

        protected BaseStep(IProcessFlowStore store)
        {
            if (store == null) throw new ArgumentNullException(nameof(store));
            _store = store;
        }
        
        public string Name => GetType().Name;
        public abstract Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument);

        public abstract Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken());

        public async Task<IStep> OnSucess(IProcessFlowArgument processFlowArgument)
        {
            
            var step =  _store.GetNextStep(processFlowArgument, StepType.Success);
            processFlowArgument.Execution.CurrentStepId = step.Id;
            var nextstep = processFlowArgument.Steps.FirstOrDefault(s => s.Name == step.NameClientAlias);
            if (nextstep == null)
            {
               throw  new Exception("Not Found Next Step Success");
            }
            return nextstep;
        }

        public async Task<IStep> OnError(IProcessFlowArgument processFlowArgument)
        {
            var step =  _store.GetNextStep(processFlowArgument, StepType.Error);
            processFlowArgument.Execution.CurrentStepId = step.Id;
            var nextstep = processFlowArgument.Steps.FirstOrDefault(s => s.Name == step.NameClientAlias);
            if (nextstep == null)
            {
                throw new Exception("Not Found Next Step Error");
            }
            return nextstep;
        }

        public void TraceFlow(IProcessFlowArgument processFlowArgument)
        {
            _store.TrackingStep(processFlowArgument);
        }
    }
}