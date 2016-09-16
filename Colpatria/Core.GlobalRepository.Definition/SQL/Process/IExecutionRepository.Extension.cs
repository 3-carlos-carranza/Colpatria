#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IExecutionRepository.Extension.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-13 - 11:37 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;
using Core.Entities.Process;

#endregion

namespace Core.GlobalRepository.SQL.Process
{
    public partial interface IExecutionRepository
    {
        Execution CreateRequest(Execution execution);
        Execution GetRequestById(long id);
        StepDetail GetNextStepWithType(int step, int section, int processId, int type);
    }
}