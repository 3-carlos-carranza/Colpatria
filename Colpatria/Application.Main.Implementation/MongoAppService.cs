using System.Collections;
using System.Collections.Generic;
using Application.Main.Definition;
using Core.Entities.Mongo;
using Core.GlobalRepository.Definition.Mongo;

namespace Application.Main.Implementation
{
    public class MongoAppService : IMongoAppService
    {
        private readonly IColpatriaLogRepository _colpatriaLogRepository;
        public MongoAppService(IColpatriaLogRepository colpatriaLogRepository)
        {
            _colpatriaLogRepository = colpatriaLogRepository;
        }

        public IEnumerable<ColpatriaLog> GetAllColpatriaLogs()
        {
            return _colpatriaLogRepository.Collection.FindAll();
        }
    }
}
