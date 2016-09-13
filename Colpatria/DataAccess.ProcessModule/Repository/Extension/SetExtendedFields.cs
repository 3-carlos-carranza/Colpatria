using System.Collections.Generic;
using System.Data;
using System.Linq;
using Crosscutting.Common.Tools.DataType;
using EntityFrameworkExtras.EF6;

namespace DataAccess.ProcessModule.Repository.Extension
{
    [StoredProcedure("dbo.SetExtendedFields")]
    public class SetExtendedFields
    {
        public SetExtendedFields(IEnumerable<FieldValueOrder> collection, long executionid, int companyid)
        {
            KeyValues = collection.Select(kv => new KeyValue
            {
                Id = kv.KeyInt,
                Value = kv.Value,
                Bytes = kv.Bytes,
                Applicant = kv.Applicant,
                CollectionNumber = kv.Order
            }).ToList();

            ExecutionId = executionid;
            CompanyId = companyid;
        }

        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<KeyValue> KeyValues { get; set; }

        [StoredProcedureParameter(SqlDbType.BigInt)]
        public long ExecutionId { get; set; }

        [StoredProcedureParameter(SqlDbType.Int)]
        public int CompanyId { get; set; }
    }
}