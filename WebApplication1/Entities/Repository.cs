using MongoRepository;

namespace WebApplication1
{
    public class Repository<T>:MongoRepository<T> where T:Entity
    {
        public Repository()
            :base("mongodb://192.168.99.100:27017/reader"){
        }
    }
}