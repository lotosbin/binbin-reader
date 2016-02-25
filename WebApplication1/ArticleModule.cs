using System.Linq;
using MongoRepository;
using Nancy;

namespace WebApplication1 {
    public class ArticleModule : NancyModule {
        private readonly Repository<Article> _articleRepository;
        public ArticleModule(Repository<Article> articleRepository)
            : base("articles") {
                this._articleRepository = articleRepository;
            Get["/"] = p => {
                return this._articleRepository.Take(100).ToList();
            };
            Post["/"] = p => {
                return "";
            };
        }
    }
}