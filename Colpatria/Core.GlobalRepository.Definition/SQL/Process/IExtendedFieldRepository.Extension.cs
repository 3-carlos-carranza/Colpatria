﻿using System.Collections.Generic;
using Core.Entities.SQL.Process;
using Crosscutting.Common.Tools;
using Crosscutting.Common.Tools.DataType;

namespace Core.GlobalRepository.SQL.Process
{
    public partial interface IExtendedFieldRepository
    {
        void SetFields(List<FieldValueOrder> collection, long requestid, int ownerId);
        //PageDetail GetFieldsByPage(long userId, int pageId, long? sectionId, long request, int? appliccant = null);
        IEnumerable<Page> GetAllPagesWithSection();
    }
}