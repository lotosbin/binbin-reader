using System.Collections.Generic;
using System.Linq;
using MongoRepository;
using Nancy;
using Nancy.ModelBinding;
using WebApplication1.Services;

namespace WebApplication1
{
    public class FeedModule : NancyModule {
        public ArticleService articleService { get; set; }
        private FeedService feedService { get; set; }
        private readonly Repository<Feed> _feedRepository;
        private readonly Repository<Article> _articleRository;
        public FeedModule(ArticleService articleService,
        Repository<Feed> feedRepository,
        Repository<Article> articalRepository,
        FeedService feedService)
            : base("feeds") {
            this.articleService = articleService;
            this._feedRepository = feedRepository;
            this._articleRository = articalRepository;
            this.feedService = feedService;
            Get["/"] = p => {
                var list = this._feedRepository.ToList();
                return list;
            };
            Post["/"] = p => {
                //add feed url
                var f = this.Bind<Feed>();
                var newFeed = feedService.AddFeed(f.Url);
                articleService.UpdateArticle(newFeed);
                return "";
            };
            Get["import"] = p => {
                var f = new Feed() {
                    Url = "http://mapei.blog.51cto.com/rss.php?uid=356827"
                };
                this._feedRepository.Add(f);
                return "";
            };
            Get["{id}/detail"] = p => {
                var feed = this._feedRepository.GetById(p.id);
                List<Article> list = new List<Article>();
                if (feed != null) {
                    string id = feed.Id.ToString();
                    list = this._articleRository.Where(a => a.SourceId == id).ToList();
                    return list;
                }
                return list;
            };
            Post["{id}/detail"] = p => {
                var feed = this._feedRepository.GetById(p.id);
                if (feed != null)
                    articleService.UpdateArticle(feed);
                return "";
            };
        }
    }
}