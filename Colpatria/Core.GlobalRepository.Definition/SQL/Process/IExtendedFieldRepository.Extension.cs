﻿#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IExtendedFieldRepository.Extension.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 11:12 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Core.DataTransferObject.Vib;
using Core.Entities.Process;
using Crosscutting.Common.Tools.DataType;

#endregion

namespace Core.GlobalRepository.SQL.Process
{

    public partial interface ISectionRepository
    {
        StepDetail GetCurrentStepDetailByExecutionId(long executionId);

    }

    public partial interface IExtendedFieldRepository
    {
        void SetFields(IEnumerable<FieldValueOrder> collection, long requestid);
        //PageDetail GetFieldsByPage(long userId, int pageId, long? sectionId, long request, int? appliccant = null);
        IEnumerable<Page> GetAllPagesWithSection();
    }
}