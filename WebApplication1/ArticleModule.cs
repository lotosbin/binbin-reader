using System;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;

namespace WebApplication1
{
    public class ArticleModule : NancyModule {
        private readonly Repository<Article> _articleRepository;
        public ArticleModule(Repository<Article> articleRepository)
            : base("articles") {
                this._articleRepository = articleRepository;
            Get["/"] = p => {
                return this._articleRepository.Take(100).ToList();
            };
            Post["/"] = p => {
                var data = this.Bind<Article>();
                var article = new Article("",data.ThirdId,data.Title,DateTime.Now);
                _articleRepository.Add(article);
                return article;
            };
        }
    }
}