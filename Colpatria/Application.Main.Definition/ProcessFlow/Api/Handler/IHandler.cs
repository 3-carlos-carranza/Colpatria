#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IHandler.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-24  - 9:10 a. m.</Date>
//   <Update> 2016-08-26 - 11:12 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.Handler
{
    public interface IHandler
    {
        Task<IResponse> SendAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = default(CancellationToken));

        IResponse Send(IProcessFlowArgument argument);
    }
}