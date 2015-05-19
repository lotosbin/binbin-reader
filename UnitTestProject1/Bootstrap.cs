using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Testing;
using WebApplication1;

namespace UnitTestProject1 {
    [TestClass]
    public class Bootstrap {
        public static Browser Browser { get; set; }

        [AssemblyInitialize]
        public static void Setup(TestContext context) {
            //note brower 全局只有一个实例,否则会多次执行application start up
            var bootstrapper = new CustomBootstrapper();
            Browser = new Browser(bootstrapper, to => {
                to.Accept("application/json");
                //这里必须要加User-Agent值，否则服务端会验证失败
                to.Header("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36");
            });
        }
        [AssemblyCleanup]
        public static void Teardown() {
        }
    }
}