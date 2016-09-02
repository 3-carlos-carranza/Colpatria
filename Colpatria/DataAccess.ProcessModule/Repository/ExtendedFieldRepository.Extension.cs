using System.Collections.Generic;
using System.Data.Entity;
using Crosscutting.Common.Tools;
using DataAccess.ProcessModule.Repository.Extension;
using EntityFrameworkExtras.EF6;

namespace DataAccess.ProcessModule.Repository
{
    partial class ExtendedFieldRepository
    {
        public void SetFields(List<FieldValueOrder> collection, long requestid, int ownerId)
        {
            var context = UnitOfWork as DbContext;

            var procedure = new SetExtendedFields(collection, requestid, ownerId);

            context?.Database.ExecuteStoredProcedure(procedure);
        }
    }
}