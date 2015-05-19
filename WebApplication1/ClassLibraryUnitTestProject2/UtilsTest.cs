using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ClassLibraryUnitTestProject2 {
    [TestClass]
    public class UtilsTest {
        private string _text = @"【今日Google doodle】这就是巴巴爸爸、巴巴妈妈、巴巴族、巴巴拉拉、巴巴利鲍、巴巴鲍巴、巴巴贝尔、巴巴布拉德、巴巴布拉卜，记住了吗？巴巴爸爸、巴巴妈妈、巴巴族、巴巴拉拉、巴巴利鲍、巴巴鲍巴、巴巴贝尔、巴巴布拉德、巴巴布拉卜...(Barbapapa 出版45周年)";

        [TestMethod]
        public void ChineseLetterCountTest() {
            var s = @"【今日Google doodle】这就是巴巴爸爸、巴巴妈妈、巴巴族、巴巴拉拉、巴巴利鲍、巴巴鲍巴、巴巴贝尔、巴巴布拉德、巴巴布拉卜，记住了吗？巴巴爸爸、巴巴妈妈、巴巴族、巴巴拉拉、巴巴利鲍、巴巴鲍巴、巴巴贝尔、巴巴布拉德、巴巴布拉卜...(Barbapapa 出版45周年)";
            var count = Utils.ChineseLetterCount(s);
            Assert.AreEqual(107, count);
        }

        [TestMethod]
        public void ReadTimeTest() {
            var time = Utils.ReadTime(_text);
            Debug.WriteLine(time);
        }

        [TestMethod]
        public void SplitWordTest() {
            var items = SplitWordSina.SplitWord(_text);
            Debug.WriteLine(JsonConvert.SerializeObject(items));
        }
        [TestMethod]
        public void AgingTest() {
            var aging = Utils.Aging(_text);
            Debug.WriteLine(aging);
        }

        [TestMethod]
        public void Test() {
            var feed = GetFeedItems("http://36kr.com/feed");
            Debug.WriteLine(JsonConvert.SerializeObject(feed));
            Debug.WriteLine("-----------------------------------");
            var list = new List<dynamic>();
            foreach (var item in feed.Items) {
                string content = "";
                if (item.Summary != null) {
                    content = item.Summary.Text;
                }
                if (item.Content != null) {
                    content = item.Content.ToString();
                }
                var readTime = Utils.ReadTime(content);
                var aging = Utils.Aging(content);
                list.Add(new { item, content, readTime, aging });
            }
            foreach (dynamic r in list.OrderBy(e => e.readTime).ThenByDescending(e => e.aging)) {
                Debug.WriteLine("===================");
                Debug.WriteLine((string)r.content);
                Debug.WriteLine((float)r.readTime);
                Debug.WriteLine((int)r.aging);
            }
        }

        private SyndicationFeed GetFeedItems(string url) {
            using (var r = XmlReader.Create(url)) {
                return SyndicationFeed.Load(r);
            }
        }
    }
}
