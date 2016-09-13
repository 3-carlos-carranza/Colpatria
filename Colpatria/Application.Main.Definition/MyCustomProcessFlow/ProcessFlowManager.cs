#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ProcessFlowManager.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 11:56 a. m.</Date>
//   <Update> 2016-09-09 - 1:00 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;

#endregion

namespace Application.Main.Definition.MyCustomProcessFlow
{
    public abstract class ProcessFlowManager : IProcessFlowManager
    {
        protected ProcessFlowManager(IEnumerable<IStep> steps, IProcessFlowStore store)
        {
            Steps = steps;
            Store = store;
        }

        public IEnumerable<IStep> Steps { get; }
        public IProcessFlowStore Store { get; }


        public virtual async Task<IProcessFlowResponse> StartFlow(IProcessFlowArgument arg,
            Func<IProcessFlowArgument, IProcessFlowResponse> actionToStart)
        {
            arg.Steps = Steps;
            if (actionToStart != null)
            {
                return actionToStart.Invoke(arg);
            }
            var step =  Store.GetCurrentStep(arg);
            return await Steps.First(s => s.Name == step.NameClientAlias).Advance(arg);
        }

        public async Task<IProcessFlowResponse> StartFlowAsync(IProcessFlowArgument arg,
            Func<IProcessFlowArgument, IProcessFlowResponse> actionToStart)
        {
            arg.Steps = Steps;
            var step =  Store.GetCurrentStep(arg);
            return await Steps.First(s => s.Name == step.NameClientAlias).Advance(arg);
        }
    }
}