#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ColpatriaProcessFlowManager.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 12:00 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Application.Main.Definition.MyCustomProcessFlow;
using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;

#endregion

namespace Application.Main.Implementation.ProcessFlow
{
    public class ColpatriaProcessFlowManager : ProcessFlowManager
    {
        //public async Task<IStepResponse> RunFlow(IProcessFlowArgument processFlowArgument)
        //{
        //    //Creo la solicitud
        //    InitializeStepArgument(processFlowArgument);

        //    var step = processFlowArgument.StepArgument.Execution.CurrentStepId;

        //    var stepobj = _stepRepository.Get(s => s.Id == step);
        //    var steps = stepobj.NameClientAlias.Split(Convert.ToChar("|"));

        //    if (processFlowArgument.IsSubmitting)
        //    {
        //        var submittableStep = Steps.First(s => s.Name == steps[1]);
        //        if (submittableStep != null)
        //        {
        //            return await submittableStep.Advance(processFlowArgument.StepArgument);
        //        }
        //    }
        //    return await Steps.First(s => s.Name == steps[0]).Advance(processFlowArgument.StepArgument);
        //}

        //private void InitializeStepArgument(IProcessFlowArgument processFlowArgument)
        //{
        //    processFlowArgument.StepArgument.Steps = Steps;

        //    var processid =
        //        _productProcessRepository.GetFiltered
        //            (s => s.ProductId == processFlowArgument.ExecutionArgument.ProductId).FirstOrDefault();

        //    if (processFlowArgument.StepArgument.Execution == null)
        //    {
        //        var submitFormArgument = processFlowArgument.StepArgument as ProcessFlowArgument;
        //        var c = submitFormArgument?.Form.ToList();
        //        var request = new Execution
        //        {
        //            CreateDate = DateTime.UtcNow,
        //            IsActive = true,
        //            ProcessId = processid.Id,
        //            ProductId = processFlowArgument.ExecutionArgument.ProductId,
        //            SimpleId = ToolExtension.GenSemiUniqueId(),
        //            UserId = processFlowArgument.ExecutionArgument.UserId,
        //            CurrentStepId = _stepRepository.GetFirstStepbyProcess(processid.ProcessId).Id,
        //            State = (int) ExecutionState.Requesting,
        //            ProductData = @"{}"
        //        };
        //        processFlowArgument.StepArgument.Execution = _executionRepository.CreateRequest(request);
        //        processFlowArgument.IsSubmitting = true;
        //    }
        //    else
        //    {
        //        processFlowArgument.StepArgument.Execution =
        //            _executionRepository.GetRequestById(processFlowArgument.StepArgument.Execution.Id);
        //    }
        //    processFlowArgument.StepArgument.Execution.UserId = processFlowArgument.ExecutionArgument.UserId;
        //}

        public ColpatriaProcessFlowManager(IEnumerable<IStep> steps, IProcessFlowStore store) : base(steps, store)
        {
        }
    }
}