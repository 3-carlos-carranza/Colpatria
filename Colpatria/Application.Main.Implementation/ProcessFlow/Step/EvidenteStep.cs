using System;
using System.Threading.Tasks;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Steps;
using Core.Entities.Evidente;
using Core.GlobalRepository.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class EvidenteStep : BaseStep, IEvidenteStep
    {
        private readonly ValidateUserSettingsBuilder _validateUserSettingsBuilder;
        private readonly QuestionsSettingsBuilder _questionsSettingsBuilder;
        private readonly IEvidenteAppService _evidenteAppService;
        public EvidenteStep(IExecutionRepository executionRepository, 
            IStepRepository stepRepository,
            IExtendedFieldRepository extendedFieldRepository, IEvidenteAppService evidenteAppService) 
            : base(executionRepository, stepRepository, extendedFieldRepository)
        {
            _evidenteAppService = evidenteAppService;
            _validateUserSettingsBuilder = new ValidateUserSettingsBuilder();
            _questionsSettingsBuilder = new QuestionsSettingsBuilder();
        }

        public int SectionId { get; set; }
        public int StepId { get; set; }
        public string Name => GetType().Name;
        public Task<IStepResponse> Advance(IStepArgument stepArgument)
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
    }
}