using System.Collections.Generic;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Steps;
using Core.Entities.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Arguments
{
    public class StepArgument : IStepArgument
    {
        public Execution Execution { get; set; }
        public string Username { get; set; }
        public IEnumerable<IStep> Steps { get; set; }
    }
}