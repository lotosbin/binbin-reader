using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassLibrary1 {
    /// <summary>
    /// http://bbs.xunsearch.com/showthread.php?tid=1235
    /// </summary>
    public class WordAttribute
    {
        
    }
    public class SplitWord {
        public virtual List<SplitWordResultItem> Execute(string text)
        {
            return null;
        }
    }
    public class SplitWordResultItem {
        public int index { get; set; }
        public string word { get; set; }
        public string word_tag { get; set; }
    }

    [Serializable]
    public class SplitWordException : Exception {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public SplitWordException() {
        }

        public SplitWordException(string message)
            : base(message) {
        }

        public SplitWordException(string message, Exception inner)
            : base(message, inner) {
        }

        protected SplitWordException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }
    }
}