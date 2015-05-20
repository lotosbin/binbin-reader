using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Services;

namespace UnitTestProject1.Services {
    [TestClass]
    public class FeedServcieTest {
        [TestMethod]
        public void LoadOpmlTest() {
            new FeedService().LoadOpml();
        }
    }
}