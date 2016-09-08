using System.Collections.Generic;
using Core.Entities.Process;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IShowScreenResponse : IInterfaceWebResponse
    {
        IShowScreenResponse Make { get; }
        IEnumerable<Page> Pages { get; set; }
        //PageDetail PageDetail { get; set; }
    }
}