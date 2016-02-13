using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;
using MongoRepository;

namespace WebApplication1.Services
{
    public class FeedService {
        public void LoadOpml() {
            var uri = "http://anve-server01/opml.xml";
            var doc = XDocument.Load(uri);
            // grab any level, but only the ones that have a valid xmlUrl attribute
            // using a LINQ Query over the XDocument:

            IEnumerable<string> query = from attrib in doc.Descendants("outline").Attributes("xmlUrl") select attrib.Value;

            //create a List of type SyndicationFeed
            List<SyndicationFeed> feeds = new List<SyndicationFeed>();
            // foreach (string url in urls)
            foreach (string s in query) {

                try {
                    AddFeed(s);
                } catch {
                    /*uh-oh, bad format, let's skip him */
                }
            }
        }

        public Feed AddFeed(string url) {
            var feed = GetFeedItems(url);
            var exists = new MongoRepository<Feed>().Exists(e => e.Url == url);
            if (exists) return null;
            var f = new Feed(url) {
                Title = feed.Title.Text,
                LastUpdatedTime = feed.LastUpdatedTime.DateTime
            };
            var feeds = new MongoRepository<Feed>();
            feeds.Add(f);
            return f;
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
    }
}