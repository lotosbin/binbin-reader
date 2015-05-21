using MongoRepository;

namespace WebApplication1
{
    public class Account : Entity {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}