using System;
using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.Responses;
using Core.Entities.SQL.Enumerations;
using Core.Entities.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ShowModalResponse : IShowScreenResponse
    {
        public Guid ProductId { get; set; }
        public long RequestId { get; set; }
        public int PageId { get; set; }
        public int SectionId { get; set; }
        public string Code { get; set; }
        public ExecutionState RequestState { get; set; }
        public IShowScreenResponse Make => new ShowScreenResponse();
        public InterfaceTypeResponse InterfaceTypeResponse => InterfaceTypeResponse.ShowModal;
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public IEnumerable<Page> Pages { get; set; }
        //public PageDetail PageDetail { get; set; }
    }
}