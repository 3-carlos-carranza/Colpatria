#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IStepRepository.Extension.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 11:16 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Core.Entities.Process;

#endregion

namespace Core.GlobalRepository.SQL.Process
{
    partial interface IStepRepository
    {
        Step GetFirstStepbyProcess(int processid);
    }
}