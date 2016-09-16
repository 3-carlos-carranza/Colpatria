using System;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Application.Main.Implementation.ProcessFlow.Responses;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class ResponseRequestAppService : IResponseRequestAppService
    {
        public IRequestResponse GetResponse()
        {
            return new RequestResponse()
            {
                Name = "Carlos Carranza",
                DateOfExpedition = DateTime.UtcNow,
                MessageClassification = MessageClassification.Approved,
                IsResponsePersonalized = false,
            };
        }
    }
}