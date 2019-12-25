using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public class Interpreter
    {
        private List<Token> Tokens;
        public int TokensSize
        {
            get
            {
                return Tokens.Capacity;
            }
        }

        public Interpreter(List<Token> tokens)
        {
            Tokens = tokens;
        }

        public void Interprete()
        {
            //current token
            Token[] token = new Token[TokensSize];
            //all tokens in code
            Token[] tArr = Tokens.ToArray();

            //add tokens
            int index = 0;
            foreach(Token tok in tArr)
            {
                token[index] = tok;
                index++;
            }

            //current token index
            int itoken = 0;
            //read tokens
            foreach (Token current in tArr)
            {
                //execute if not null
                if(current.StepExecute!=null)
                    current.StepExecute(token, itoken);

                //change current index
                itoken++;
            }
        }
    }
}
