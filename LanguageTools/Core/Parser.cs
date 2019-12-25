using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VoltFramework.LanguageTools
{
    public static class ParserAlgorithms
    {
        public static string ReplaceOnlyInQuotes(this string source,string oldVal,string newVal)
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
        public static string ReplaceOnlyInBrackets(this string source,string oldVal,string newVal)
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

    public class Parser
    {
        private string Source { get; set; }

        public Parser(string source)
        {
            Source = source;
        }

        public string[] CustomParser(char splitter)
        {
            List<string> res = new List<string>();
            foreach (string w in Source.Split(splitter))
            {
                if (w != null && w.Trim() != "")
                    res.Add(w);
            }
            return res.ToArray();
        }
        public string[] ParseWords(List<ParserSeparator> separators)
        {
            //process source lines
            string source = Source.Replace("\n", " ");

            //process separators
            foreach(ParserSeparator sep in separators)
            {
                if (sep.Type == SeparatorType.SeparateAfter)
                {
                    source = source.Replace(sep.Char, sep.Char + sep.SeparatorCode);
                }
                else if (sep.Type == SeparatorType.SeparateBefore)
                {
                    source = source.Replace(sep.Char, sep.SeparatorCode + sep.Char);
                }
                else if (sep.Type == SeparatorType.SeparateBoth)
                {
                    source = source.Replace(sep.Char, sep.SeparatorCode + sep.Char + sep.SeparatorCode);
                }
                else if (sep.Type == SeparatorType.Replace)
                {
                    source = source.Replace(sep.Char, sep.SeparatorCode);
                }
            }
            //process spaces in quotes
            source = source.ReplaceOnlyInQuotes(" ", @"\sp\");

            //Console.WriteLine(source);

            //process key splitters
            List<string> split = new List<string>();
            split.Add(" ");
            foreach(ParserSeparator sep in separators)
            {
                if (sep.Splitter == true)
                    split.Add(sep.SeparatorCode);
            }
            
            //process words
            List<string> res = new List<string>();
            foreach(string w in source.Split(split.ToArray(), StringSplitOptions.None))
            {
                if (w != null && w.Trim() != "")
                    res.Add(w);
            }
            return res.ToArray();
        }
        public char[] ParseChars()
        {
            List<char> res = new List<char>();
            foreach(char c in Source.ToCharArray())
            {
                if (c != ' ')
                    res.Add(c);
            }
            return res.ToArray();
        }
    }
}
