#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-30  - 3:13 p. m.</Date>
//   <Update> 2016-08-30 - 4:23 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api
{
    public interface IStep
    {
        string Name { get; }

        Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument);

        Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IStep> OnSucess(IProcessFlowArgument processFlowArgument);
        Task<IStep> OnError(IProcessFlowArgument processFlowArgument);
        void TraceFlow(IProcessFlowArgument processFlowArgument);
    }
}