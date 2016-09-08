#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=EvidenteStep.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 3:26 p. m.</Date>
//   <Update> 2016-09-08 - 11:46 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps;
#endregion

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class EvidenteStep : BaseStep, IEvidenteStep
    {
        private readonly ValidateUserSettingsBuilder _validateUserSettingsBuilder;
        private readonly QuestionsSettingsBuilder _questionsSettingsBuilder;
        private readonly IEvidenteAppService _evidenteAppService;
        {
            _evidenteAppService = evidenteAppService;
            _validateUserSettingsBuilder = new ValidateUserSettingsBuilder();
            _questionsSettingsBuilder = new QuestionsSettingsBuilder();
        }

        public int SectionId { get; set; }
        public int StepId { get; set; }
        public string Name => GetType().Name;

        public override Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            //var validationSettings =
            //    _validateUserSettingsBuilder.WithIdentification("1023924856")
            //        .WithTypeOfDocument("1")
            //        .WithLastName("")
            //        .WithSecondLastName("")
            //        .WithExpeditionDate(DateTime.UtcNow)
            //        .WithFullName("")
            //        .WithExecutionId(stepArgument.Execution.Id)
            //        .Build();

            //var validationResponse = _evidenteAppService.Validate(validationSettings);

            //if (!validationResponse.ProcessResult)
            //{
            //   // return OnError.Advance(BuildError(stepArgument, "/", "Error", "Reintentar", "Ha ocurrido un error con nuestro buró de créditos", false));
            //}

            //if (!validationResponse.Success)
            //{
            //    //return this.OnError.Advance(BuildError(stepArgument, "/Account/LogOff", "Su solicitud no ha sido aprobada", "Salir", "Apreciado Usuario: el proceso de solicitud no puede continuar.", true));
            //}

            var questionsResponse =
                _evidenteAppService.GetQuestions(_questionsSettingsBuilder.WithDocumentNumber("")
                        .WithTypeOfDocument("1")
                        .WithValidationNumber(1)
                        .WithExecutionId(stepArgument.Execution.Id)
                        .Build());

            if (questionsResponse.MaximumAttemptsPerDay)
            {
                //return this.OnError.Advance(BuildError(stepArgument, "/Account/LogOff", "Intentos superados", "Salir", "Ha superado los intentos diarios permitidos. Intentar mañana", true));
            }

            if (questionsResponse.MaximumAttemptsPerMonth)
            {
                //return this.OnError.Advance(BuildError(stepArgument, "/Account/LogOff", "Intentos superados", "Salir", "Ha superado los intentos mensuales permitidos. Intentar en un mes", true));
            }
            if (questionsResponse.MaximumAttemptsPerYear)
            {
                //return this.OnError.Advance(BuildError(stepArgument, "/Account/LogOff", "Su solicitud no ha sido aprobada", "Salir", "Apreciado Usuario: el proceso de solicitud no puede continuar. Superó máximos intentos permitidos", true));
            }
            
            throw new NotImplementedException("falta la Implementación para el paso del servicio EVIDENTE");

        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}