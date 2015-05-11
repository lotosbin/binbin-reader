using System.Linq;
using MongoRepository;
using Nancy;

namespace WebApplication1 {
    public class FeedModule : NancyModule {

        public FeedModule()
            : base("feeds") {
            Get["/"] = p => {
                var list = new MongoRepository<Feed>().ToList();
                return list;
            };
            Post["/"] = p => {
                //add feed url
                var f = new Feed() {
                    Url = p.url
                };
                var feeds = new MongoRepository<Feed>();
                feeds.Add(f);
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
        }
    }
}