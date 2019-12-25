using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public enum MarkerFormat
    {
        Text,Regex,Rule
    }
    public interface TokenMarker
    {
        MarkerFormat Type { get; }
        string Rule { get; set; }
    }

    public class TextTokenMarker : TokenMarker
    {
        public MarkerFormat Type { get { return MarkerFormat.Text; } }
        public string Rule { get; set; }

        public TextTokenMarker(string text)
        {
            Rule = text;
        }
    }
    public class RegexTokenMarker : TokenMarker
    {
        public MarkerFormat Type { get { return MarkerFormat.Regex; } }
        public string Rule { get; set; }

        public RegexTokenMarker(string regex)
        {
            Rule = regex;
        }
    }

    public enum RuleType
    {
        StartsWith,EndsWith,StartsAndEndsWith
    }

    public class RuleTokenMarker : TokenMarker
    {
        public MarkerFormat Type { get { return MarkerFormat.Rule; } }
        public string Rule { get; set; }
        public RuleType RuleType { get; set; }

        public RuleTokenMarker(string rule,RuleType t)
        {
            Rule = rule;
            RuleType = t;
        }
    }
}
