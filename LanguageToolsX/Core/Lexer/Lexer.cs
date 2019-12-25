using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageToolsX.Core
{
    public class Lexer
    {
        private List<Token> InitializedTokens = new List<Token>();

        public Lexer()
        {

        }

        public void AddToken(Token t)
        {
            if (TokenExist(t.Name) == false)
                InitializedTokens.Add(t);
            else
                Logger.ErrorCatch(new RuntimeError("Token already exists in lexer(token name:" + t.Name + ")"));
        }
        public bool TokenExist(string name)
        {
            bool res = false;
            foreach(Token t in InitializedTokens)
            {
                if (t.Name == name)
                    res = true;
            }
            return res;
        }

        public Token TokenizeWord(string word)
        {
            Token res = new Token("UNKNOWN", null);
            foreach (Token t in InitializedTokens)
            {
                if (t.Match(word))
                { res = new Token(t, word); }
            }
            return res;
        }

        public List<Token> DoLexAnalysis(string[] words)
        {
            List<Token> res = new List<Token>();
            foreach(string word in words)
            {
                res.Add(TokenizeWord(word));
            }
            return res;
        }
        public List<Token> DoLexAnalysis(StringParser p,string code)
        {
            string[] words = p.Parse(code);
            return DoLexAnalysis(words);
        }
    }
}
