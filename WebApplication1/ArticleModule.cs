using System.Linq;
using MongoRepository;
using Nancy;

namespace WebApplication1 {
    public class ArticleModule : NancyModule {
        public ArticleModule()
            : base("articles") {
            Get["/"] = p => {
                return new MongoRepository<Article>().Take(100).ToList();
            };
            Post["/"] = p => {
                return "";
            };
        }
    }
}