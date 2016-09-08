#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IDynamicAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 10:17 a. m.</Date>
//   <Update> 2016-09-08 - 3:11 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Core.Entities.Process;

#endregion

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IDynamicAppService
    {
        ExtendedField GetRequestFieldByUserAndProccess(int field, int idprocess);
        IEnumerable<ExtendedDataList> GetDataListValues(long iddatalist, long? parent = null);
    }
}