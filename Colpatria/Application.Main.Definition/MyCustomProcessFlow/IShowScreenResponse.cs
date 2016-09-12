using System.Collections.Generic;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Core.Entities.Process;

namespace Application.Main.Definition.MyCustomProcessFlow
{
    public interface IShowScreenResponse : IInterfaceResponse
    {
        IShowScreenResponse Make { get; }
        IEnumerable<Page> Pages { get; set; }
    }
}