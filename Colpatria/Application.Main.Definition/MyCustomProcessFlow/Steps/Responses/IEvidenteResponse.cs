using System.Collections.Generic;
using Core.Entities.Evidente;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IEvidenteResponse : IInterfaceWebResponse
    {
        IEnumerable<Question> Questions { get; set; }
    }
}
