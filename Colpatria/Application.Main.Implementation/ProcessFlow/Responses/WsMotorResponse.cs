using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Model;
using Core.Entities.WsMotor;

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class WsMotorResponse : IWsMotorResponse
    {
        public ErrorWsMotorResponse ErrorWsMotorResponse { get; set; }
        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public ShowScreenType ShowScreenType => ShowScreenType.ShowForm;
        public string Name { get; set; }
    }
}