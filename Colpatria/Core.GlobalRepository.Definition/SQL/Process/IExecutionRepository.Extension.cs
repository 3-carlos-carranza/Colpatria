using System;
using Core.DataTransferObject.Vib;
using Core.Entities.Enumerations;
using Core.Entities.Process;

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