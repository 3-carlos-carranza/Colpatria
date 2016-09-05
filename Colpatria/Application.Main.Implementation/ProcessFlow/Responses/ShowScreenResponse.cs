using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.Responses;
using Core.Entities.SQL.Enumerations;
using Core.Entities.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ShowScreenResponse : IShowScreenResponse
    {
        public InterfaceTypeResponse InterfaceTypeResponse => InterfaceTypeResponse.ShowForm;
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public IShowScreenResponse Make => new ShowScreenResponse();
        public IEnumerable<Page> Pages { get; set; }
        public long RequestId { get; set; }
        public int PageId { get; set; }
        public int SectionId { get; set; }
        public string Code { get; set; }
        public ExecutionState ExecutionState { get; set; }
        //public PageDetail PageDetail { get; set; }
    }
}