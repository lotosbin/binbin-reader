using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Testing;

namespace UnitTestProject1 {
    [TestClass]
    public class AccountModuleTest {
        private Browser _browser = Bootstrap.Browser;
        [TestMethod]
        public void GetTest() {
            var response = this._browser.Get("/accounts/18121629620");
            Debug.WriteLine(response.Body.AsString());
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void Post_Test() {
            var response = this._browser.Post("/accounts/");
            Debug.WriteLine(response.Body.AsString());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}