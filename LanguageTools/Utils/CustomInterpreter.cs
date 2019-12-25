using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools.Utils
{
    public static class CustomInterpreter
    {
        public static void Interprete(this Token[] code)
        {
            //current token
            Token[] token = new Token[code.Length];

            //add tokens
            int index = 0;
            foreach (Token tok in code)
            {
                token[index] = tok;
                index++;
            }

            //current token index
            int itoken = 0;
            //read tokens
            foreach (Token current in code)
            {
                //execute if not null
                if (current.StepExecute != null)
                    current.StepExecute(token, itoken);

                //change current index
                itoken++;
            }
        }
        public static void Interprete(this Token[] code, ActionsList acts)
        {
            //current token
            Token[] token = new Token[code.Length];

            //add tokens
            int index = 0;
            foreach (Token tok in code)
            {
                token[index] = tok;
                index++;
            }

            //current token index
            int itoken = 0;
            //read tokens
            foreach (Token current in code)
            {
                //execute if not null
                if (current.StepExecute != null)
                    current.StepExecute(token, itoken);
                //execute described action
                foreach (DescribedAction act in acts.GetList())
                {
                    if (current.Name == act.TOKEN_NAME)
                        act.Action(code, itoken);
                }
                //change current index
                itoken++;
            }
        }
        public static void Interprete(this Token[] code,ActionsList acts,Action<Token[],int> tokProc)
        {
            //current token
            Token[] token = new Token[code.Length];

            //add tokens
            int index = 0;
            foreach (Token tok in code)
            {
                token[index] = tok;
                index++;
            }

            //current token index
            int itoken = 0;
            //read tokens
            foreach (Token current in code)
            {
                //execute if not null
                if (current.StepExecute != null)
                    current.StepExecute(token, itoken);
                //execute described action
                foreach(DescribedAction act in acts.GetList())
                {
                    if (current.Name == act.TOKEN_NAME)
                        act.Action(code,itoken);
                }
                tokProc(code, itoken);
                //change current index
                itoken++;
            }
        }
        public static void Interprete(this Workspace code,List<ParserSeparator> seps,List<Token> toks)
        {
            code.ToOneCode(seps,toks).Interprete();
        }
        public static void Interprete(this Workspace code, List<ParserSeparator> seps, List<Token> toks,ActionsList acts)
        {
            code.ToOneCode(seps, toks).Interprete(acts);
        }
    }
}
