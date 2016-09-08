using System.Collections.Generic;
using Core.Entities.Logging;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface ILoggingAppService
    {
        IEnumerable<ColpatriaLog> GetAllColpatriaLogs();
    }
}
