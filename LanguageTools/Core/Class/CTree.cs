using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public class CTree
    {
        public string Name { get; set; }
        public Token[] Code { get; set; }
        public RootNode Root { get; }

        public CTree(string name,Token[] code)
        {
            Name = name;
            Root = new RootNode("Root");
            Code = code;
        }

        public ICNode FindNode(string name)
        {
            ICNode res = Root.FindNode(name);
            return res;
        }

        public CodeBlockNode[] GetRootCodeBlockNodes()
        {
            List<CodeBlockNode> res = new List<CodeBlockNode>();
            foreach(ICNode node in Root.Childs)
            {
                if (node is CodeBlockNode)
                    res.Add((CodeBlockNode)node);
            }
            return res.ToArray();
        }
        public TokenNode[] GetRootTokenNodes()
        {
            List<TokenNode> res = new List<TokenNode>();
            foreach (ICNode node in Root.Childs)
            {
                if (node is TokenNode)
                    res.Add((TokenNode)node);
            }
            return res.ToArray();
        }
        public void AddNodeToRoot(ICNode nod)
        {
            Root.Childs.Add(nod);
        }

        private void printCodeblockNode(ICNode node)
        {
            if(node is CodeBlockNode)
            {
                CodeBlock cb =(CodeBlock)node.Value;
                Console.WriteLine(node.Name + ":");
                Console.WriteLine(" (" + cb.Start.ToString() + "," + cb.End.ToString() + ")");
            }
            foreach (ICNode c in node.Childs)
                printCodeblockNode(c);
        }
        private void printNode(ICNode node)
        {
            Console.WriteLine(node.Name);
            foreach (ICNode c in node.Childs)
                printNode(c);
        }
        private void printTokenNode(ICNode node)
        {
            if (node is TokenNode)
            {
                Token tok = (Token)node.Value;
                Console.WriteLine(tok.Name+"("+tok.Text+")");
            }
            foreach (ICNode c in node.Childs)
                printTokenNode(c);
        }
        private void printCodeNodes_block(ICNode node,string space)
        {
            if (node is CodeBlockNode)
            {
                CodeBlock cb = (CodeBlock)node.Value;
                Console.WriteLine(space+"[block]" + ":");
            }
            foreach (ICNode c in node.Childs)
            {
                if (c is TokenNode)
                    printCodeNodes_token(c,space+"  ");
                else if (c is CodeBlockNode)
                    printCodeNodes_block(c,space+"  ");
            }
        }
        private void printCodeNodes_token(ICNode node,string space)
        {
            if (node is TokenNode)
            {
                Token tok = (Token)node.Value;
                Console.WriteLine(space+tok.Text + " - " + tok.Name + "");
            }
        }
        private void printCodeNodes(ICNode node)
        {
            string space = "";
            if (node is TokenNode)
            {
                printCodeNodes_token(node,space);
            }
            else if (node is CodeBlockNode)
            {
                printCodeNodes_block(node,space);
            }
            foreach (ICNode c in node.Childs)
            {
                if (c is TokenNode)
                    printCodeNodes_token(c,space);
                else if (c is CodeBlockNode)
                    printCodeNodes_block(c,space);
            }
        }

        public void print()
        {
            printNode(Root);
        }
        public void printCodeblock()
        {
            printCodeblockNode(Root);
        }
        public void printCodetree()
        {
            printCodeNodes(Root);
        }
    }
}
