using System.Collections.Generic;
using Core.Entities.Mongo;

namespace Application.Main.Definition
{
    public interface IMongoAppService
    {
        IEnumerable<ColpatriaLog> GetAllColpatriaLogs();
    }
}
