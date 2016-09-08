#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IProcessFlowManager.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-05  - 4:09 p. m.</Date>
//   <Update> 2016-09-06 - 2:54 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.ProcessFlows
{
    public interface IProcessFlowManager
    {
        IEnumerable<IStep> Steps { get; }

        IProcessFlowStore Store { get; }

        Task<IProcessFlowResponse> StartFlow(IProcessFlowArgument arg,
            Func<IProcessFlowArgument, IProcessFlowResponse> actionToStart);

        Task<IProcessFlowResponse> StartFlowAsync(IProcessFlowArgument arg,
            Func<IProcessFlowArgument, IProcessFlowResponse> actionToStart);
    }
}