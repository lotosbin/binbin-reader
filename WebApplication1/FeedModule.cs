using MongoRepository;
using Nancy;

namespace WebApplication1 {
    public class FeedModule : NancyModule {

        public FeedModule()
            : base("feeds") {
            Get["/"] = parameters => "Hello World";
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
    public class Feed : Entity {
        public string Url { get; set; }
    }
}