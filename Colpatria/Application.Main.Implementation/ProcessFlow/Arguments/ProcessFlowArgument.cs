//   -----------------------------------------------------------------------
//   <copyright file=ProcessFlowArgument.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

#region

using System.Collections;
using System.Collections.Generic;
using Banlinea.ProcessFlow.Engine.Api;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Model;
using Crosscutting.Common.Tools.DataType;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Arguments
{
    public class ProcessFlowArgument : IProcessFlowArgument
    {
        public IList<FieldValueOrder> Form { get; set; }
        public int OwnerId { get; set; }

        public ExecutionFlow Execution { get; set; }
        public IProcessFlowUser User { get; set; }
        public bool IsSubmitting { get; set; }
        public IEnumerable<IStep> Steps { get; set; }
    }
}