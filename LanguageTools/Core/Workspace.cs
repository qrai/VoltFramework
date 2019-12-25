using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoltFramework.LanguageTools.Descriptors;
using VoltFramework.LanguageTools.Memory;
namespace VoltFramework.LanguageTools
{
    public class Workspace
    {
        public CodeFile[] Files { get; }

        public Workspace(CodeFile[] files)
        {
            Files = files;
        }

        public Token[] ToOneCode(List<ParserSeparator> separators,List<Token> toks)
        {
            string source = "";
            foreach(CodeFile file in Files)
            {
                source += "\n" + file.Code;
            }


            Parser p = new Parser(source);
            string[] words = p.ParseWords(separators);

            Lexer l = new Lexer(words, toks);
            Token[] res = l.LexAnalysis().ToArray();
            return res;
        }
    }
}
