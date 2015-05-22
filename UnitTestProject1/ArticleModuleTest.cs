using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Testing;
using WebApplication1;

namespace UnitTestProject1 {
    [TestClass]
    public class ArticleModuleTest {
        private Browser _browser = Bootstrap.Browser;

        [TestMethod]
        public void TestMethod1() {
            var response = this._browser.Get("/articles");
            Debug.WriteLine(response.Body.AsString());
        }
    }
}
