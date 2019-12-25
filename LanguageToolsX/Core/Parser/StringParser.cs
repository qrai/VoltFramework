using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VoltFramework.LanguageToolsX.Core
{
    public static class ParserAlgorithms
    {
        public static string ReplaceOnlyInQuotes(this string source, string oldVal, string newVal)
        {
            //1. get all strings between all quotes
            string s = source;
            Regex regex = new Regex(@"\'.*?\'");
            MatchCollection matches = regex.Matches(s);

            //2. create dictionary with list of string that need to replace
            Dictionary<string, string> reps = new Dictionary<string, string>();
            foreach (Match m in matches)
            {
                reps.Add(m.Value, m.Value.Replace(oldVal, newVal));
            }

            //3. replace strings that is in "reps" in source
            foreach (string key in reps.Keys)
            {
                string toRep;
                reps.TryGetValue(key, out toRep);

                s = s.Replace(key, toRep);
            }

            return s;
        }
        public static string ReplaceOnlyInBrackets(this string source, string oldVal, string newVal)
        {
            //1. get all strings between all quotes
            string s = source;
            Regex regex = new Regex(@"\(.*?\)");
            MatchCollection matches = regex.Matches(s);

            //2. create dictionary with list of string that need to replace
            Dictionary<string, string> reps = new Dictionary<string, string>();
            foreach (Match m in matches)
            {
                reps.Add(m.Value, m.Value.Replace(oldVal, newVal));
            }

            //3. replace strings that is in "reps" in source
            foreach (string key in reps.Keys)
            {
                string toRep;
                reps.TryGetValue(key, out toRep);

                s = s.Replace(key, toRep);
            }

            return s;
        }
    }

    public class ParsedCode
    {
        private List<string[]> Code;
        public ParsedCode(List<string[]> code)
        {
            Code = code;
        }
    }
    public class StringParser
    {
        private string[] chars;
        public StringParser(string[] langChars)
        {
            chars = langChars;
        }

        public string[] Parse(string str)
        {
            List<string> lines = str.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //splitters
            List<string> split = new List<string>();
            split.Add(" ");
            //special chars
            int i = 0;
            foreach (string ch in chars)
            {
                int li = 0;
                foreach(string source in lines)
                {
                    string source2 = source.Replace(ch, "/" + i + "/" + ch + "/" + i + "/");
                    lines[li] = source2;
                    li++;
                }
                split.Add("/" + i + "/");
                i++;
            }
            //strings
            str = str.ReplaceOnlyInQuotes(" ", @"\sp\");

            //process words
            List<string> res = new List<string>();
            foreach (string w in str.Split(split.ToArray(), StringSplitOptions.None))
            {
                if (w != null && w.Trim() != "")
                    res.Add(w);
            }
            return res.ToArray();
        }
    }
}
