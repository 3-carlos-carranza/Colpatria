#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IStartFlowStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 10:17 a. m.</Date>
//   <Update> 2016-09-08 - 11:37 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;

#endregion

namespace Application.Main.Definition.MyCustomProcessFlow.Steps
{
    public interface IStartFlowStep : IStep
    {
        void MakeCustomProcess(IProcessFlowArgument stepArgument);
    }
}