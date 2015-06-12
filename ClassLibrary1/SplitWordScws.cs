using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace ClassLibrary1 {
    /// <summary>
    /// http://www.ftphp.com/scws/api.php
    /// </summary>
    public class SplitWordScws : SplitWord {
        public class SplitResult {
            public class SplitResultItem {
                public string word { get; set; }
                public int off { get; set; }
                public string idf { get; set; }
                public string attr { get; set; }
            }
            public string status { get; set; }
            public string message { get; set; }
            public List<SplitResultItem> words { get; set; }
        }
        public override List<SplitWordResultItem> Execute(string text) {
            var client = new RestClient("http://www.ftphp.com");
            var request = new RestRequest("/scws/api.php", Method.POST);
            request.AddParameter("data", text);
            request.AddParameter("respond", "json");
            request.AddParameter("charset", "utf8");
            request.AddParameter("ignore", "yes");
            request.AddParameter("duality", "no");
            request.AddParameter("traditional", "no");
            request.AddParameter("multi", "0");
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            var result = JsonConvert.DeserializeObject<SplitResult>(content);
            if (result.status != "ok") {
                throw new SplitWordException(result.message);
            }
            return result.words.Select(w => new SplitWordResultItem() {
                index = w.off,
                word = w.word,
                word_tag = w.attr,
            }).ToList();
        }

    }
}