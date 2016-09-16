using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowAdditionalInformationStep : BaseStep
    {
        public ShowAdditionalInformationStep(IProcessFlowStore store) : base(store)
        {
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            TraceFlow(argument);
            if (!argument.IsSubmitting)
            {
                var step = (StepDetail)GetCurrentStep(argument);
                return new AdditionalInformationResponse
                {
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
            }
            Console.WriteLine("Submitting form...Guardando campos");
            argument.IsSubmitting = false;
            return await OnSuccess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}
