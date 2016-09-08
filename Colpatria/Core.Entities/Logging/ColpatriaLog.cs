using MongoRepository;

namespace Core.Entities.Logging
{
    [CollectionName("ColpatriaLog")]
    public class ColpatriaLog : Entity
    {
        public string CreatedDate { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
