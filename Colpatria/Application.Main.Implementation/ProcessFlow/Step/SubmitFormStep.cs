#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=SubmitFormStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 11:51 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps;

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

            return await (await OnSucess(arg)).Advance(arg);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}