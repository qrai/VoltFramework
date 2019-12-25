using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public enum SeparatorType
    {
        SeparateAfter, SeparateBefore, SeparateBoth, Replace
    }

    public class ParserSeparator
    {
        public bool Splitter { get; set; }
        public SeparatorType Type { get; set; }
        public string Char { get; set; }

        private string CodeOnly = null;
        public string SeparatorCode { get { return @"\s" + CodeOnly + @"\"; } set { CodeOnly = value; } }

        public ParserSeparator(string character, string sepCode, SeparatorType t, bool splitter)
        {
            Char = character;
            SeparatorCode = sepCode;
            Type = t;
            Splitter = splitter;
        }
    }
}
