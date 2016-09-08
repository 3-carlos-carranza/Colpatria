using System.Collections.Generic;
using Core.Entities.Process;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IDynamicAppService
    {
        ExtendedField GetRequestFieldByUserAndProccess(int field, int idprocess);
        IEnumerable<ExtendedDataList> GetDataListValues(long iddatalist, long? parent = null);
    }
}