using System;
using Core.DataTransferObject.SQL;
using Core.Entities.SQL.Enumerations;
using Core.Entities.SQL.Process;

namespace Core.GlobalRepository.SQL.Process
{
    public partial interface IExecutionRepository
    {
        Execution CreateRequest(Execution execution);
        Execution GetRequestById(long id);
        Execution GetLatestRequest(long userId, long product, int process, string requestType);
        Execution GetRequestbyUserAndRequestSimpleId(long userId, string simpleId, long product);
        StepDetail GetNextStepWithType(int step, int section, int processId, StepType type);
    }
}