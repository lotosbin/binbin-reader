using System;
using System.Diagnostics;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryUnitTestProject2 {
    [TestClass]
    public class UtilsTest {
        [TestMethod]
        public void ChineseLetterCountTest() {
            var s = @"【今日Google doodle】这就是巴巴爸爸、巴巴妈妈、巴巴族、巴巴拉拉、巴巴利鲍、巴巴鲍巴、巴巴贝尔、巴巴布拉德、巴巴布拉卜，记住了吗？巴巴爸爸、巴巴妈妈、巴巴族、巴巴拉拉、巴巴利鲍、巴巴鲍巴、巴巴贝尔、巴巴布拉德、巴巴布拉卜...(Barbapapa 出版45周年)";
            var count = Utils.ChineseLetterCount(s);
            Assert.AreEqual(107, count);
        }

        [TestMethod]
        public void ReadTimeTest() {
            var s = @"【今日Google doodle】这就是巴巴爸爸、巴巴妈妈、巴巴族、巴巴拉拉、巴巴利鲍、巴巴鲍巴、巴巴贝尔、巴巴布拉德、巴巴布拉卜，记住了吗？巴巴爸爸、巴巴妈妈、巴巴族、巴巴拉拉、巴巴利鲍、巴巴鲍巴、巴巴贝尔、巴巴布拉德、巴巴布拉卜...(Barbapapa 出版45周年)";
            var time = Utils.ReadTime(s);
            Debug.WriteLine(time);
        }
    }
}
