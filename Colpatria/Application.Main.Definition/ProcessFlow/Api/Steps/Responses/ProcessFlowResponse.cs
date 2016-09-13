#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ProcessFlowResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-25  - 8:47 a. m.</Date>
//   <Update> 2016-08-26 - 11:39 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Core.Entities.ProcessModel;


#endregion

namespace Application.Main.Definition.ProcessFlow.Api.Steps.Responses
{
    public class ProcessFlowResponse : IProcessFlowResponse
    {
        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
    }
}