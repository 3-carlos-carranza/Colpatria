using System.Collections.Generic;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.Entities.Logging;
using Core.GlobalRepository.Mongo;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class LoggingAppService : ILoggingAppService
    {
        private readonly IColpatriaLogRepository _colpatriaLogRepository;
        public LoggingAppService(IColpatriaLogRepository colpatriaLogRepository)
        {
            _colpatriaLogRepository = colpatriaLogRepository;
        }

        public IEnumerable<ColpatriaLog> GetAllColpatriaLogs()
        {
            return _colpatriaLogRepository.Collection.FindAll();
        }
    }
}
