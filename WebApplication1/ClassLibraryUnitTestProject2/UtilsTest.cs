using System;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryUnitTestProject2 {
    [TestClass]
    public class UtilsTest {
        [TestMethod]
        public void ChineseLetterCountTest() {
            var s = "";
            var count = Utils.ChineseLetterCount(s);
            Assert.AreEqual(0, count);
        }
    }
}
