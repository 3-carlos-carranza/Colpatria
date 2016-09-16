//   -----------------------------------------------------------------------
//   <copyright file=SubmitFormStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.ProcessFlow.Engine.Api;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitFormStep : BaseStep, IStep
    {
        private readonly ISaveFieldsAppService _saveFieldsService;

        public SubmitFormStep(IProcessFlowStore store, ISaveFieldsAppService saveFieldsService) : base(store)
        {
            _saveFieldsService = saveFieldsService;
        }

        public string Name => GetType().Name;

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument arg)
        {
            _saveFieldsService.SaveForm(arg);

            return await (await OnSuccess(arg)).Advance(arg);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}