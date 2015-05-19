using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace ClassLibrary1
{
    public class SplitWordSina : SplitWord {
        public override void Execute(string text) {
            SplitWord(text);
        }

        public class SplitWordResultItem {
            public int index { get; set; }
            public string word { get; set; }
            public int word_tag { get; set; }
        }

        public static List<SplitWordResultItem> SplitWord(string text) {
            //http://sae.sina.com.cn/doc/python/segment.html
            var client = new RestClient("http://segment.sae.sina.com.cn");
            var request = new RestRequest("/urlclient.php", Method.POST);
            request.AddParameter("encoding", "UTF-8");
            request.AddParameter("word_tag", "1");
            request.AddParameter("content", text, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            return JsonConvert.DeserializeObject<List<SplitWordResultItem>>(content);
            //var response = client.Post<List<SplitWordResultItem>>(request);
            //Debug.WriteLine(JsonConvert.SerializeObject(response));
            //return response.Data;
        }
    }
}