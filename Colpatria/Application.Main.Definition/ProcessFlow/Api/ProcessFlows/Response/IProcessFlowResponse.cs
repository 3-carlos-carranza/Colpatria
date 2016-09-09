#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IProcessFlowResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-26  - 11:16 a. m.</Date>
//   <Update> 2016-08-26 - 11:17 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region



#endregion

#region

using Core.Entities.ProcessModel;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response
{
    public interface IProcessFlowResponse
    {
        ExecutionFlow Execution { get; set; }
        ResponseDetailFlow ResponseDetail { get; set; }
    }
}