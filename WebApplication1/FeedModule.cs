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
        public FeedModule()
            : base("feeds") {
            articleService = new ArticleService();
            feedService = new FeedService();
            Get["/"] = p => {
                var list = new MongoRepository<Feed>().ToList();
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
                var feeds = new MongoRepository<Feed>();
                feeds.Add(f);
                return "";
            };
            Get["{id}/detail"] = p => {
                var feed = new MongoRepository<Feed>().GetById(p.id);
                List<Article> list = new List<Article>();
                if (feed != null) {
                    var articals = new MongoRepository<Article>();
                    string id = feed.Id.ToString();
                    list = articals.Where(a => a.SourceId == id).ToList();
                    return list;
                }
                return list;
            };
            Post["{id}/detail"] = p => {
                var feed = new MongoRepository<Feed>().GetById(p.id);
                if (feed != null)
                    articleService.UpdateArticle(feed);
                return "";
            };
        }
    }
}