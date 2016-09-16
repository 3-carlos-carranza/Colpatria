using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.DataTransferObject.Vib;
using Core.Entities.Process;
using Crosscutting.Common.Tools.DataType;
using DataAccess.ProcessModule.Repository.Extension;
using EntityFrameworkExtras.EF6;

namespace DataAccess.ProcessModule.Repository
{
    partial class ExtendedFieldRepository
    {
        public void SetFields(List<FieldValueOrder> collection, long requestid)
        {
            var context = UnitOfWork as DbContext;

            var procedure = new SetExtendedFields(collection, requestid);

            context?.Database.ExecuteStoredProcedure(procedure);
        }

        public IEnumerable<Page> GetAllPagesWithSection()
        {
            var context = UnitOfWork as DbContext;
            var result = context?.Database.SqlQuery<MapperPagesWithSections>("GetAllPagesWithSection").ToList();
            return result.Map();
        }
    }
}