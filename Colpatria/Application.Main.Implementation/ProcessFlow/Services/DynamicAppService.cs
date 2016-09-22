#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=DynamicAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 11:50 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Linq;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.Entities.Process;
using Core.GlobalRepository.SQL.Process;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Services
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

        public IEnumerable<ExtendedDataList> GetDataListFilterValues(long iddatalist, string filter, long? parent = null)
        {
            if (parent == null)
            {

                if (string.IsNullOrEmpty(filter))
                {
                  return  _extendedDataListRepository.GetFiltered(x => x.ListId == iddatalist)
                     .OrderBy(o => o.Value)
                     .Take(100)
                     .ToList();
                }
                return
                    _extendedDataListRepository.GetFiltered(x => x.ListId == iddatalist)
                        .OrderBy(o => o.Value)
                        .Where(f => f.Value.Contains(filter))
                        .Take(100)
                        .ToList();
            }

            var item = parent.GetValueOrDefault();

            return _extendedDataListRepository
                .GetFiltered(x => x.ListId == iddatalist && x.IdParent == item)
                .OrderBy(o => o.Value).ToList();
        }
    }
}