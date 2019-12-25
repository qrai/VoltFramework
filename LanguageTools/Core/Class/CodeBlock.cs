using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public interface ICodeBlock
    {
        int Start { get; set; }
    }

    public class CodeBlock : ICodeBlock
    {
        public int Start { get; set; }
        public int End { get; set; }

        public CodeBlock(int start,int end)
        {
            Start = start;
            End = end;
        }
        public CodeBlock(NotEndedCodeBlock cb,int end)
        {
            Start = cb.Start;
            End = end;
        }
    }

    public class NotEndedCodeBlock : ICodeBlock
    {
        public int Start { get; set; }

        public NotEndedCodeBlock(int start)
        {
            Start = start;
        }
    }
}
