using Core.GlobalRepository.Mongo;
using Data.MongoModule.Repository;
using Microsoft.Practices.Unity;

namespace Data.MongoModule
{
    public static class MongoDependencies
    {
        public static void InitializeMongoRepository(this IUnityContainer container)
        {
            container.RegisterType<IColpatriaLogRepository, ColpatriaLogRepository>();
        }
    }
}