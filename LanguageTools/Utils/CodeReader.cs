using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VoltFramework.LanguageTools.Utils
{
    public static class CodeReader
    {
        public static string ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string res = sr.ReadToEnd();
            sr.Close();
            return res;
        }
        public static Workspace FilesToWorkspace(string[] paths)
        {
            List<CodeFile> files = new List<CodeFile>();
            foreach (string path in paths)
            {
                files.Add(new CodeFile(ReadFile(path)));
            }
            return new Workspace(files.ToArray());
        }
        public static Token[] FileToTokens(string path,List<ParserSeparator> seps, List<Token> toks)
        {
            return TextToTokens(ReadFile(path),seps,toks);
        }
        public static Token[] TextToTokens(string text,List<ParserSeparator> seps,List<Token> toks)
        {
            Parser parser = new Parser(text);
            string[] words = parser.ParseWords(seps);
            Lexer lex = new Lexer(words, toks);
            return lex.LexAnalysis().ToArray();
        }
    }
}
