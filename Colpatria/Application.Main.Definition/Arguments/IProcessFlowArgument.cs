﻿using Core.DataTransferObject.SQL;

namespace Application.Main.Definition.Arguments
{
    public interface IProcessFlowArgument
    {
        ExecutionArgument ExecutionArgument { get; set; }
        StepArgument StepArgument { get; set; }
        bool IsSubmitting { get; set; }
    }
}