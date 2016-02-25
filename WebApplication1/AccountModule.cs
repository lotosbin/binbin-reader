using System.Linq;
using MongoRepository;
using Nancy;
using Nancy.ModelBinding;

namespace WebApplication1 {
    public class AccountModule : NancyModule {
        private readonly Repository<Account> _accountRepository;
        public AccountModule(Repository<Account> accountRepository)
            : base("accounts") {
                this._accountRepository = accountRepository;
            Get["/{username}"] = p => {
                string username = p.username;
                var account = this._accountRepository.SingleOrDefault(a => a.Username == username);
                if (account == null) {
                    return HttpStatusCode.NotFound;
                }
                return account;
            };
            Post["/"] = p => {
                var f = this.Bind<Account>();
                var exists = this._accountRepository.Exists(a => a.Username == f.Username);
                if (exists) {
                    return HttpStatusCode.Conflict;
                }
                var account = this._accountRepository.Add(f);
                return account;
            };
        }
    }
}