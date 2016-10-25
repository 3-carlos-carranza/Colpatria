using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;
using Core.Entities.Evidente;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ErrorEvidenteStep : BaseStep
    {
        private readonly IUserAppService _userAppService;
        private readonly IEvidenteAppService _evidenteAppService;
        public ErrorEvidenteStep(IProcessFlowStore store, IUserAppService userAppService, IEvidenteAppService evidenteAppService) : base(store)
        {
            _userAppService = userAppService;
            _evidenteAppService = evidenteAppService;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var errorEvidente = new ErrorEvidenteResponse();
            if (argument == null) throw new ArgumentNullException(nameof(argument));
            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);
            if (userInfo.EvidenteValidationUser != "Aprobado")
            {
                if (userInfo.EvidenteValidationUser == "Rechazado")
                {
                    errorEvidente.Title = "Respuesta del servicio";
                    errorEvidente.Message = "Usuario rechazado por validación de usuario";
                }else
                {
                    errorEvidente.Title = "Respuesta del servicio";
                    errorEvidente.Message = userInfo.EvidenteValidationUser;
                }
            }else if (userInfo.EvidenteQuestions != "Preguntas obtenidas con éxito")
            {
                errorEvidente.Title = "Respuesta del servicio";
                errorEvidente.Message = userInfo.EvidenteQuestions;
            }else if (userInfo.EvidenteAnswersResponse != "Aprobado")
            {
                errorEvidente.Title = "Respuesta del servicio";
                errorEvidente.Message = userInfo.EvidenteAnswersResponse;
            }
            else
            {
                errorEvidente.Title = "Respuesta del servicio";
                errorEvidente.Message = "Estamos presentado fallas, intenta más adelante";
            }
            await Task.Factory.StartNew(() => TraceFlow(argument)).ConfigureAwait(false);
            var step = await Task.Factory.StartNew(() => (StepDetail)GetCurrentStep(argument)).ConfigureAwait(false);
            var response = new EvidenteResponse
            {
                UserInfoDto = userInfo,
                ErrorEvidenteResponse = errorEvidente,
                Execution = argument.Execution,
                Action = step.Action,
                ActionMethod = step.ActionMethod,
                Controller = step.Controller,
                FriendlyUrl = (step.PageName + "/" + step.SectionName).Replace(" ", "-"),
                ResponseDetail = new ResponseDetailFlow
                {
                    Status = ReponseStatus.Success
                }
            };
            return Task.FromResult((IProcessFlowResponse)response).Result;
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}