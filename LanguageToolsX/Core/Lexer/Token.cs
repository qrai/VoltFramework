using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Threading.Tasks;

namespace VoltFramework.LanguageToolsX.Core
{
    public enum TDescriberType
    { Text,Regex,CustomRule }
    public class TokenDescriber
    {
        public TDescriberType Type {get;}
        public object Describer { get; private set; }

        public TokenDescriber(string textDesc)
        {
            Type = TDescriberType.Text;
            Describer = textDesc;
        }
        public TokenDescriber(TDescriberType type,object describer)
        {
            Type = type;
            Describer = describer;
        }
    }

    public class Token
    {
        public string Name { get; }
        public TokenDescriber Syntax {get;}
        public string Content { get; }

        public Token(string name,TokenDescriber syntax)
        {
            Name = name;
            Syntax = syntax;
        }

        public Token(Token t,string content)
        {
            Name = t.Name;
            Syntax = t.Syntax;
            Content = content;
        }

        public bool Match(string str)
        {
            if (Syntax.Type == TDescriberType.Text)
            {
                if (str == Syntax.Describer.ToString())
                    return true;
                else
                    return false;
            }
            else if (Syntax.Type == TDescriberType.Regex)
            {
                if (Regex.IsMatch(str, Syntax.Describer.ToString()))
                    return true;
                else
                    return false;
            }
            else if (Syntax.Type == TDescriberType.CustomRule && Syntax.Describer is Func<string, bool>)
            {
                Func<string, bool> act = (Func<string, bool>)Syntax.Describer;
                if (act(str))
                    return true;
                else
                    return false;
            }
            else
            {
                Logger.ErrorCatch(new AnalysisError("Unknown or invalid token describer syntax type(token name:" + Name + ")"));
                return false;
            }
        }
        public bool ContentEqualsSyntax()
        {
            return Match(Content);
        }
    }
}
