using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Core.Entities.Evidente;
using Core.Entities.ProcessModel;

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class EvidenteResponse : IEvidenteResponse
    {
        public IEnumerable<Question> Questions { get; set; }
        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public InterfaceTypeResponse InterfaceTypeResponse => InterfaceTypeResponse.ShowForm;
    }
}
