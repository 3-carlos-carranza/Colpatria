#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=SubmitFormStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-30  - 3:11 p. m.</Date>
//   <Update> 2016-08-30 - 4:34 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.Steps
{
    public class SubmitFormStep : BaseStep
    {
        public SubmitFormStep(IProcessFlowStore store) : base(store)
        {
        }

        public override Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            throw new NotImplementedException();
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}