using System.Collections.Generic;
using Core.Entities.SQL.Process;

namespace Application.Main.Definition
{
    public interface IDynamicAppService
    {
        ExtendedField GetRequestFieldByUserAndProccess(int field, int idprocess);
        IEnumerable<ExtendedDataList> GetDataListValues(long iddatalist, long? parent = null);
    }
}