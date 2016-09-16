#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ProcessFlowArgument.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-14 - 9:03 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections;
using System.Collections.Generic;
using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Core.Entities.ProcessModel;
using Crosscutting.Common.Tools.DataType;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Arguments
{
    public class ProcessFlowArgument : ISubmitFormArgument
    {
        public ExecutionFlow Execution { get; set; }
        public IProcessFlowUser User { get; set; }
        public bool IsSubmitting { get; set; }
        public IEnumerable<IStep> Steps { get; set; }
        public IList<FieldValueOrder> Form { get; set; }
    }
}