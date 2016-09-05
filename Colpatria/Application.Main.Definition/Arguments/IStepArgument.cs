using System.Collections.Generic;
using Application.Main.Definition.Steps;
using Core.Entities.SQL.Process;

namespace Application.Main.Definition.Arguments
{
    public interface IStepArgument
    {
        Execution Execution { get; set; }
        string Username { get; set; }
        IEnumerable<IStep> Steps { get; set; }
    }
}