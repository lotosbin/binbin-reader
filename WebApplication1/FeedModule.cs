using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using MongoRepository;
using Nancy;
using Nancy.ModelBinding;

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
                var f = this.Bind<Feed>();
                var feed = GetFeedItems(f.Url);
                f.Title = feed.Title.Text;
                f.LastUpdatedTime = feed.LastUpdatedTime.DateTime;
                var feeds = new MongoRepository<Feed>();
                feeds.Add(f);
                UpdateArticle(f);
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
                    UpdateArticle(feed);
                return "";
            };
        }

        private void UpdateArticle(Feed f) {
            var feed = GetFeedItems(f.Url);
            var articles = new MongoRepository<Article>();
            foreach (var item in feed.Items) {
                var artical = articles.SingleOrDefault(a => a.ThirdId == item.Id);
                if (artical != null && artical.LastUpdatedTime >= item.LastUpdatedTime.DateTime) continue;
                var article = new Article(f.Id, item.Id, item.Title.Text, item.PublishDate.DateTime);
                article.Content = item.Content.ToString();
                articles.Add(article);
            }
        }

        private SyndicationFeed GetFeedItems(string url) {
            using (var r = XmlReader.Create(url)) {
                return SyndicationFeed.Load(r);
                //foreach (SyndicationItem album in albums.Items) {

                // album.links[0].URI points to this album page on spaces.live.com
                // album.Summary (not shown) is an HTML block with thumbnails of the album pics
                //cell.Text = string.Format("<a href='{0}'>{1}</a>", album.Links[0].Uri, album.Title.Text);
                //albumRSS = GetAlbumRSS(album);
                //var r = XmlReader.Create(albumRSS);
                //photos = SyndicationFeed.Load(r);
                //r.Close();
                //foreach (SyndicationItem photo in photos.Items) {
                // photo.Summary is an HTML block with a thumbnail of the pic
                //cell.Text = string.Format("{0}", photo.Summary.Text);
                //}

                //}
            }
        }
    }
}