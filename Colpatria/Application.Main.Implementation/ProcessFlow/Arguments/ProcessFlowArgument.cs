﻿//   -----------------------------------------------------------------------
//   <copyright file=ProcessFlowArgument.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

#region

using System.Collections.Generic;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Engine.Api;
using Banlinea.ProcessFlow.Model;
using Core.Entities.Evidente;
using Crosscutting.Common.Tools.DataType;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Arguments
{
    public class ProcessFlowArgument : ISubmitFormArgument, IAnswerQuestionArgument
    {
        public ExecutionFlow Execution { get; set; }
        public IProcessFlowUser User { get; set; }
        public bool IsSubmitting { get; set; }
        public IEnumerable<IStep> Steps { get; set; }
        public IList<FieldValueOrder> Form { get;  } = new List<FieldValueOrder>();
        public AnswerRequest AnswerRequest { get; set; }
    }
}