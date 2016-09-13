using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Core.Entities.Enumerations;
using Core.Entities.Process;
using Core.Entities.ProcessModel;
using Execution = Core.Entities.ProcessModel.ExecutionFlow;
using Page = Core.Entities.Process.Page;

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ShowScreenResponse : IShowScreenResponse
    {
        public Execution Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public InterfaceTypeResponse InterfaceTypeResponse { get; }
        
        public IEnumerable<Page> Pages { get; set; }
    }
}