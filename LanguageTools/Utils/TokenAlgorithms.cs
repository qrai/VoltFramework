using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools.Utils
{
    public static class TokenAlgorithms
    {
        #region Extract
        public static Token[] Extract(this Token[] code,Token[] extractables)
        {
            List<Token> res = new List<Token>();
            foreach(Token tok in code)
            {
                foreach(Token extr in extractables)
                {
                    if (tok == extr)
                        res.Add(tok);
                }
            }
            return res.ToArray();
        }
        public static Token[] ExtractByName(this Token[] code,string[] extractables)
        {
            List<Token> res = new List<Token>();
            foreach (Token tok in code)
            {
                foreach (string extr in extractables)
                {
                    if (tok.Name == extr)
                        res.Add(tok);
                }
            }
            return res.ToArray();
        }

        public static FixedPosToken[] Extract(this FixedPosToken[] code,Token[] extractables)
        {
            List<FixedPosToken> res = new List<FixedPosToken>();
            foreach (FixedPosToken tok in code)
            {
                foreach (Token extr in extractables)
                {
                    if (tok.Token == extr)
                        res.Add(tok);
                }
            }
            return res.ToArray();
        }
        public static FixedPosToken[] ExtractByName(this FixedPosToken[] code, string[] extractables)
        {
            List<FixedPosToken> res = new List<FixedPosToken>();
            foreach (FixedPosToken tok in code)
            {
                foreach (string extr in extractables)
                {
                    if (tok.Token.Name == extr)
                        res.Add(tok);
                }
            }
            return res.ToArray();
        }
        #endregion
        #region Convert
        public static FixedPosToken[] SetPosesToCode(this Token[] code)
        {
            List<FixedPosToken> res = new List<FixedPosToken>();
            int pos = 0;
            foreach(Token tok in code)
            {
                res.Add(new FixedPosToken(tok, pos));
                pos++;
            }
            return res.ToArray();
        }
        public static Token[] ToTokens(this FixedPosToken[] code)
        {
            List<Token> res = new List<Token>();
            foreach (FixedPosToken tok in code)
            {
                res.Add(tok.Token);
            }
            return res.ToArray();
        }
        #endregion
        #region Get
        public static Token[] GetBetween(this Token[] code,int start,int end,bool includeStart,bool includeEnd)
        {
            Token[] res = null;
            if (code.Length >= start && code.Length >= end)
            {
                List<Token> toks = new List<Token>();
                int index = 1;

                if (includeStart)
                    index = 0;
                
                while (code.Length >= start + index && start + index <= end)
                {
                    if (start + index < end)
                        toks.Add(code[start + index]);
                    else if (start + index == end)
                    {
                        if (includeEnd)
                            toks.Add(code[start + index]);
                    }
                    index++;
                }

                res = toks.ToArray();
                return res;
            }
            else
                return null;
        }
        #endregion
        #region Args
        public static Token[] FindArgs(this Token[] code, int funcIndex,string token_name_ARG_START,
            string token_name_ARG_END, string token_name_ARG_CONTINUE)
        {
            List<Token> args = new List<Token>();
            if (code[funcIndex + 1].Name == token_name_ARG_START &&
                code[funcIndex + 2].Name != token_name_ARG_END)
            {
                int tkIndex = 1;
                while (code.Length >= funcIndex + 1 + tkIndex &&
                    code[funcIndex + 1 + tkIndex].Name != token_name_ARG_END)
                {
                    if (tkIndex != 1)
                    {
                        if (code[funcIndex + 1 + tkIndex - 1].Name == token_name_ARG_CONTINUE)
                        {
                            args.Add(code[funcIndex + 1 + tkIndex]);
                        }
                    }
                    else
                        args.Add(code[funcIndex + 1 + tkIndex]);
                    tkIndex++;
                }
            }
            return args.ToArray();
        }
        #endregion
        #region Tree
        public static CTree GetCodeBlocks(this Token[] code,string token_name_CODEBLOCK_START,
            string token_name_CODEBLOCK_END)
        {
            CTree tree = new CTree("blocksTree",code);
            FixedPosToken[] blocks = code.SetPosesToCode();

            ICNode root = tree.Root;
            ICNode parent = null;
            foreach(FixedPosToken tok in blocks)
            {
                if(tok.Token.Name==token_name_CODEBLOCK_START)
                {
                    if (parent == null)
                    {
                        ICNode n = new CodeBlockNode(blocks[tok.Position - 1].Token.Text, root);

                        n.Value = new NotEndedCodeBlock(tok.Position);
                        root.Childs.Add(n);
                        parent = n;
                    }
                    else
                    {
                        ICNode n = new CodeBlockNode(blocks[tok.Position - 1].Token.Text, parent);
                        n.Value = new NotEndedCodeBlock(tok.Position);
                        parent.Childs.Add(n);
                        parent = n;
                    }
                }
                else if (tok.Token.Name == token_name_CODEBLOCK_END)
                {
                    NotEndedCodeBlock cb = (NotEndedCodeBlock)parent.Value;
                    parent.Value = new CodeBlock(cb, tok.Position);
                    if (parent.Parent != null)
                        parent = parent.Parent;
                    else
                        parent = null;
                }
            }

            tree.Root.Childs = root.Childs;
            //tree.printCodeblock();
            return tree;
        }

        public static CTree GetCodeTree(this Token[] code,string token_name_CODEBLOCK_START,
            string token_name_CODEBLOCK_END)
        {
            CTree tree = new CTree("codeTree",code);
            FixedPosToken[] blocks = code.SetPosesToCode();

            ICNode root = tree.Root;
            ICNode parent = null;
            foreach (FixedPosToken tok in blocks)
            {
                if (tok.Token.Name == token_name_CODEBLOCK_START)
                {
                    if (parent == null)
                    {
                        ICNode n = new CodeBlockNode(blocks[tok.Position - 1].Token.Text, root,
                            new NotEndedCodeBlock(tok.Position));
                        root.Childs.Add(n);
                        parent = n;
                    }
                    else
                    {
                        ICNode n = new CodeBlockNode(blocks[tok.Position - 1].Token.Text, parent,
                            new NotEndedCodeBlock(tok.Position));
                        n.Value = new NotEndedCodeBlock(tok.Position);
                        parent.Childs.Add(n);
                        parent = n;
                    }
                }
                else if (tok.Token.Name == token_name_CODEBLOCK_END)
                {
                    NotEndedCodeBlock cb = (NotEndedCodeBlock)parent.Value;
                    parent.Value = new CodeBlock(cb, tok.Position);
                    if (parent.Parent != null)
                        parent = parent.Parent;
                    else
                        parent = null;
                }
                else
                {
                    if (parent != null)
                        parent.AddNode(new TokenNode(tok.Token.Name, parent,tok.Token));
                    else
                        root.AddNode(new TokenNode(tok.Token.Name, root, tok.Token));
                }
            }

            tree.Root.Childs = root.Childs;
            //tree.printCodeblock();
            return tree;
        }
        #endregion
        #region FindPos
        public static int FindPosOfFirst(Token[] code,string token_name)
        {
            int res = -1;
            int i = 0;
            bool found = false;
            foreach(Token t in code)
            {
                if (t.Name == token_name)
                {
                    if (found == false)
                        res = i;
                }
                i++;
            }
            return res;
        }
        public static int FindPosOfLast(Token[] code, string token_name)
        {
            int res = -1;
            int i = 0;
            foreach (Token t in code)
            {
                if (t.Name == token_name)
                    res = i;
                i++;
            }
            return res;
        }
        #endregion
    }
}