using System;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface ICustomActionAppService
    {
        void GoToStep<T>(T enumerador, long requestId) where T : struct, IComparable, IFormattable, IConvertible;
    }
}