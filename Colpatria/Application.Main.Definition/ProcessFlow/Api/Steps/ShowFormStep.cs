#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ShowFormStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-05  - 4:09 p. m.</Date>
//   <Update> 2016-09-06 - 3:19 p. m.</Update>
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
    public class ShowFormStep : BaseStep
    {
        public ShowFormStep(IProcessFlowStore store) : base(store)
        {
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            TraceFlow(argument);
            Console.WriteLine("Advance Step " + Name);
            if (!argument.IsSubmitting)
            {
                Console.WriteLine("Showing data...");
                return await OnSucess(argument).Result.Advance(argument);
            }
            argument.IsSubmitting = false;
            Console.WriteLine("Submitting data...");
            return await OnSucess(argument).Result.Advance(argument);
        }

        public override async Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            TraceFlow(argument);
            Console.WriteLine("Advance Step " + Name);
            if (!argument.IsSubmitting)
            {
                Console.WriteLine("Showing data...");
                return await OnSucess(argument).Result.Advance(argument);
            }

            Console.WriteLine("Submitting data...");
            return await OnSucess(argument).Result.Advance(argument);
        }
    }
}