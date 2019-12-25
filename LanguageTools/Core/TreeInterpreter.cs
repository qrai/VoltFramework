using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoltFramework.LanguageTools.Utils;
namespace VoltFramework.LanguageTools
{
    public class TreeCodeBlock
    {
        public CodeBlock Block { get; set; }
        private CTree Tree;
        public Token[] Tokens
        {
            get
            {
                if (Block != null)
                {
                    Token[] toks = Tree.Code.GetBetween(Block.Start, Block.End, false, false);
                    return toks;
                }
                else
                    throw new Exception("Block was null");
            }
        }

        public TreeCodeBlock(CTree tree,CodeBlock block)
        {
            Block = block;
            Tree = tree;
        }
        public TreeCodeBlock(CTree tree, int indexStart,int indexEnd)
        {
            Block = new CodeBlock(indexStart, indexEnd);
            Tree = tree;
        }
    }

    public class TreeInterpreter
    {
        private CTree Tree;

        public TreeInterpreter(CTree tree)
        {
            Tree = tree;
        }

        public void Interprete(TreeCodeBlock block)
        {
            if (block.Tokens!=null)
            {
                block.Tokens.Interprete();
            }
            else
                throw new Exception("tokens was null");
        }
    }
}
