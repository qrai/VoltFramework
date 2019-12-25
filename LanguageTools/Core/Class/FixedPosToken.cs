using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public class FixedPosToken
    {
        public Token Token { get; }
        public int Position { get; }

        public FixedPosToken(Token tok,int pos)
        {
            Token = tok;
            Position = pos;
        }
    }
}
