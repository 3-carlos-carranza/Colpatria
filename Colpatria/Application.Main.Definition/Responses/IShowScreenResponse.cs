using System.Collections.Generic;
using Core.Entities.SQL.Process;

namespace Application.Main.Definition.Responses
{
    public interface IShowScreenResponse : IInterfaceResponse
    {
        IShowScreenResponse Make { get; }
        IEnumerable<Page> Pages { get; set; }
        //PageDetail PageDetail { get; set; }
    }
}