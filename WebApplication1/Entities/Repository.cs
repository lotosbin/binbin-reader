using MongoRepository;

namespace WebApplication1
{
    public class Repository<T>:MongoRepository<T> where T:Entity
    {
        public Repository()
            :base("mongodb://readermongodb:27017/reader"){
        }
    }
}