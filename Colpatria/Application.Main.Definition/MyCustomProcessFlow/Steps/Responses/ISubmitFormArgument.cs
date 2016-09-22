//   -----------------------------------------------------------------------
//   <copyright file=ISubmitFormArgument.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Core.Entities.Evidente;
using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{

    public interface IAnswerQuestionArgument : IProcessFlowArgument
    {
        AnswerRequest AnswerRequest { get; set; }
    }

    public interface ISubmitFormArgument : IProcessFlowArgument
    {
        IList<FieldValueOrder> Form { get; set; }
    }
}