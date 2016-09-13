﻿using System.Configuration;
using Core.Entities.Logging;
using Core.GlobalRepository.Mongo;
using MongoRepository;

namespace Data.MongoModule.Repository
{
    public class ColpatriaLogRepository : MongoRepository<ColpatriaLog>, IColpatriaLogRepository
    {
        private static readonly string Cnn = ConfigurationManager.ConnectionStrings["MongoServerSettings"].ToString();

        public ColpatriaLogRepository()
            : base(Cnn, "ColpatriaLog")
        {
        }
    }
}