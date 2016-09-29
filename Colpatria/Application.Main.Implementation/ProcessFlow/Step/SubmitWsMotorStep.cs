using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Core.Entities.WsMotor;
using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitWsMotorStep : BaseStep, ISubmitWsMotorStep
    {
        private readonly WsMotorRequestSettingsBuilder _wsMotorRequestSettingsBuilder;
        private readonly ISaveFieldsAppService _saveFieldsAppService;
        private readonly IWsMotorAppService _wsMotorAppService;
        private readonly IUserAppService _userAppService;

        

        public SubmitWsMotorStep(IProcessFlowStore store,
            IWsMotorAppService wsMotorAppService,
            WsMotorRequestSettingsBuilder petitionSettingsBuilder,
            ISaveFieldsAppService saveFieldsAppService, IUserAppService userAppService)
            : base(store)
        {
            _wsMotorAppService = wsMotorAppService;
            _saveFieldsAppService = saveFieldsAppService;
            _userAppService = userAppService;
            _wsMotorRequestSettingsBuilder = new WsMotorRequestSettingsBuilder();
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);

            var wsMotorRequest = _wsMotorRequestSettingsBuilder.WithIdentificaction(userInfo.Identification)
                .WithExecutionId(argument.Execution.Id)
                .WithLastName(userInfo.LastName)
                .WithTypeIdentification("1")
                .WithParamsRequest(new List<Parameter>
                {
                    new Parameter
                    {
                        Type = "T",
                        Name = "Ingresos",
                        Value = userInfo.Income
                    }
                }).Build();

            var response = _wsMotorAppService.Validate(wsMotorRequest);

            if (response.ScoresMotor.ScoreMotor.Classification == "A")
            {
                var saveFieldsAppService = argument as ProcessFlowArgument;
                saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "30", Value = "Aprobada" });
                _saveFieldsAppService.SaveForm(saveFieldsAppService);
                return await OnSuccess(argument).Result.Advance(argument);
            }

            return await OnError(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}