using System;
using MongoRepository;

namespace WebApplication1 {
    public class Article : Entity {
        private Article() {

        }
        public Article(string sourceId, string thirdId, string title, DateTime lastUpdatedTime)
            : this() {
            SourceId = sourceId;
            ThirdId = thirdId;
            Title = title;
            LastUpdatedTime = lastUpdatedTime;
        }

        /// <summary>
        ///  来源编号
        /// </summary>
        public string SourceId { get; set; }
        /// <summary>
        /// 外部唯一编号
        /// </summary>
        public string ThirdId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}