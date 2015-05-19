using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 {
    public class Utils {
        public static int ChineseLetterCount(string strText) {
            byte[] byts = Encoding.GetEncoding("gb2312").GetBytes(strText);
            return byts.Length - strText.Length;
        }

        public static float ReadTime(string text) {
            var readRate = 1000.0f;
            return ChineseLetterCount(text) / readRate;
        }
    }
}
