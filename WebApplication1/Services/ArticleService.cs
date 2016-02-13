using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using MongoRepository;

namespace WebApplication1.Services
{
    public class ArticleService {

        public void UpdateAll() {
            var feeds = new MongoRepository<Feed>();
            foreach (var feed in feeds) {
                try {
                    UpdateArticle(feed);
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message + ex.StackTrace);
                }
            }
        }

        public SyndicationFeed GetFeedItems(string url) {
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

        public void UpdateArticle(Feed f) {
            var feed = GetFeedItems(f.Url);
            var articles = new MongoRepository<Article>();
            foreach (var item in feed.Items) {
                var artical = articles.SingleOrDefault(a => a.ThirdId == item.Id);
                if (artical != null && artical.LastUpdatedTime >= item.LastUpdatedTime.DateTime) continue;
                var article = new Article(f.Id, item.Id, item.Title.Text, item.PublishDate.DateTime) {
                };
                if (item.Summary != null) article.Content = item.Summary.Text;
                articles.Add(article);
            }
        }
    }
}