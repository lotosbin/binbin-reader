using System;
using System.ServiceModel.Syndication;
using MongoRepository;

namespace WebApplication1
{
    public class Feed : Entity {
        public Feed() {
            this.AddTime = DateTime.Now;
        }

        public Feed(string url)
            : this() {
            Url = url;
            }

        public DateTime AddTime { get; set; }

        public string Url { get; set; }
        public string Title { get; set; }
    }
}