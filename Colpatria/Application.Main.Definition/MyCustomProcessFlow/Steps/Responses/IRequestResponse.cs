using System;
using Application.Main.Definition.Enumerations;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IRequestResponse : IShowScreenResponse
    {
        string Name { get; set; }
        DateTime DateOfExpedition { get; set; }
        MessageClassification MessageClassification { get; }
        bool IsResponsePersonalized { get; set; }
    }
}