using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace VoltFramework.LanguageTools
{
    
    public class Lexer
    {
        public string[] Words { get; set; }
        public List<Token> Tokens { get; }
        public Lexer(string[] words,List<Token> tokens)
        {
            Tokens = tokens;
            Words = words;
        }

        /// <summary>
        /// Convert strings to tokens by marker
        /// </summary>
        /// <returns></returns>
        public List<Token> LexAnalysis()
        {
            List<Token> res = new List<Token>();
            foreach(string word in Words)
            {
                Token r = new Token("UNKNOWN", null);
                foreach(Token possible in Tokens)
                {
                    //TEXT
                    if (possible.Marker.GetType() == typeof(TextTokenMarker))
                    {
                        if (word == possible.Marker.Rule)
                            r = possible;
                    }
                    //RULE
                    else if(possible.Marker.GetType() == typeof(RuleTokenMarker))
                    {
                        Console.WriteLine(word);
                    }
                    //REGEX
                    else if (possible.Marker.GetType() == typeof(RegexTokenMarker))
                    {
                        try
                        {
                            if (Regex.IsMatch(word, possible.Marker.Rule))
                                r = possible;
                        }
                        catch { }
                    }
                }
                //Console.WriteLine("token-text:" + word);
                //Console.WriteLine("token-name:" + r.Name);
                //Console.WriteLine(" ");
                r.Text = word.Replace(@"\sp\", " ");
                res.Add(r);
            }
            return res;
        }
    }
}
