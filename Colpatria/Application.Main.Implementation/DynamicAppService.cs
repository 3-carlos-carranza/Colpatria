using System.Collections.Generic;
using System.Linq;
using Application.Main.Definition;
using Core.Entities.SQL.Process;
using Core.GlobalRepository.SQL.Process;

namespace Application.Main.Implementation
{
    public class DynamicAppService : IDynamicAppService
    {
        private readonly IExtendedDataListRepository _extendedDataListRepository;
        private readonly IExtendedFieldRepository _extendedFieldRepository;

        public DynamicAppService(IExtendedDataListRepository extendedDataListRepository,
            IExtendedFieldRepository extendedFieldRepository)
        {
            _extendedDataListRepository = extendedDataListRepository;
            _extendedFieldRepository = extendedFieldRepository;
        }

        public ExtendedField GetRequestFieldByUserAndProccess(int field, int idprocess)
        {
            return _extendedFieldRepository.Get(f => f.BaseFieldId == field && f.ProcessId == idprocess);
        }

        public IEnumerable<ExtendedDataList> GetDataListValues(long iddatalist, long? parent = null)
        {
            if (parent == null)
            {
                return
                    _extendedDataListRepository.GetFiltered(x => x.ListId == iddatalist)
                        .OrderBy(o => o.Value)
                        .ToList();
            }

            var item = parent.GetValueOrDefault();

            return _extendedDataListRepository
                .GetFiltered(x => x.ListId == iddatalist && x.IdParent == item)
                .OrderBy(o => o.Value).ToList();
        }
    }
}