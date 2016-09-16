#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ErrorResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-05  - 11:34 a. m.</Date>
//   <Update> 2016-09-08 - 2:22 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Model;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ErrorResponse : IStepResponse
    {
        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
    }
}