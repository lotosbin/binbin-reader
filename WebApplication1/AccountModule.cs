using System.Linq;
using MongoRepository;
using Nancy;
using Nancy.ModelBinding;

namespace WebApplication1 {
    public class AccountModule : NancyModule {
        public AccountModule()
            : base("accounts") {
            Get["/{username}"] = p => {
                string username = p.username;
                var account = new MongoRepository<Account>().SingleOrDefault(a => a.Username == username);
                if (account == null) {
                    return HttpStatusCode.NotFound;
                }
                return account;
            };
            Post["/"] = p => {
                var f = this.Bind<Account>();
                var exists = new MongoRepository<Account>().Exists(a => a.Username == f.Username);
                if (exists) {
                    return HttpStatusCode.Conflict;
                }
                var account = new MongoRepository<Account>().Add(f);
                return account;
            };
        }
    }
}