using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Core.Entities.Enumerations;
using Core.Entities.ProcessModel;

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class RedirectResponse : IInterfaceWebResponse
    {
        public Execution Execution { get; set; }
        public ResponseDetail ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public InterfaceTypeResponse InterfaceTypeResponse { get; }
    }
}