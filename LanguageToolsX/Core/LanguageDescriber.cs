using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageToolsX.Core
{
    public class LanguageDescriber
    {
        private Lexer lexer;
        private Parser parser;
        private StringParser sparser;

        public LanguageDescriber(Lexer l,Parser p,StringParser sp)
        {
            lexer = l;
            parser = p;
            sparser = sp;
        }

        public List<Token> DoLexAnalysis(string code)
        {
            return lexer.DoLexAnalysis(sparser, code);
        }

        public void DoParsing()
        {

        }
        public void DoCompiling()
        {

        }
        public void DoExecuting()
        {

        }
    }
}
