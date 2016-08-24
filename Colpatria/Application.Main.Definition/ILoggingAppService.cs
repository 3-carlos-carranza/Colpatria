using System.Collections.Generic;
using Core.Entities.Mongo;

namespace Application.Main.Definition
{
    public interface ILoggingAppService
    {
        IEnumerable<ColpatriaLog> GetAllColpatriaLogs();
    }
}
