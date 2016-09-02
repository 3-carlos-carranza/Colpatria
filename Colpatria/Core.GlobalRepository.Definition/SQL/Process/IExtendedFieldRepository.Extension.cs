using System.Collections.Generic;
using Core.Entities.SQL.Process;
using Crosscutting.Common.Tools;

namespace Core.GlobalRepository.Definition.SQL.Process
{
    public partial interface IExtendedFieldRepository
    {
        void SetFields(List<FieldValueOrder> collection, long requestid, int ownerId);
        //PageDetail GetFieldsByPage(long userId, int pageId, long? sectionId, long request, int? appliccant = null);
        //IEnumerable<Page> GetAllPagesWithSection();
    }
}