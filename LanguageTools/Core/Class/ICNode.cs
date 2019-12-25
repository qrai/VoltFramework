using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public static class CNodeUtils
    {
        public static void AddNode(this ICNode par,string name)
        {
            par.Childs.Add(par);
        }
        public static void AddNode(this ICNode par,ICNode obj)
        {
            ICNode nod = obj;
            nod.Parent = par;
            par.Childs.Add(nod);
        }

        public static void RemoveNode(this ICNode par,string name)
        {
            foreach(ICNode nod in par.Childs)
            {
                if (nod.Name == name)
                    par.Childs.Remove(nod);
            }
        }
        public static void RemoveNode(this ICNode par,ICNode obj)
        {
            foreach (ICNode nod in par.Childs)
            {
                if (nod == obj)
                    par.Childs.Remove(nod);
            }
        }

        public static ICNode FindNode(this ICNode node, string name)
        {
            ICNode res = null;
            bool found = false;
            foreach (ICNode nod in node.Childs)
            {
                if (found == false)
                {
                    if (nod.Name != name)
                    {
                        ICNode f = FindNode(nod, name);
                        if (f != null)
                        {
                            res = f;
                            found = true;
                        }
                    }
                    else
                    {
                        res = nod;
                        found = true;
                    }
                }
            }
            return res;
        }

        public static void ClearNodes(this ICNode par)
        {
            par.Childs.Clear();
        }

    }

    public interface ICNode
    {
        string Name { get; set; }
        object Value { get; set; }
        ICNode Parent { get; set; }
        List<ICNode> Childs { get; set; }
    }
    public class RootNode : ICNode
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public ICNode Parent { get; set; }
        public List<ICNode> Childs { get; set; }

        public RootNode(string name)
        {
            Name = name;
            Value = null;
            Parent = null;
            Childs = new List<ICNode>();
        }
    }
    public class CodeBlockNode : ICNode
    {
        public string Name { get; set; }
        /// <summary>
        /// Value is ICodeBlock(CodeBlock or NotEndedCodeBlock)
        /// </summary>
        public object Value { get; set; }
        public ICNode Parent { get; set; }
        public List<ICNode> Childs { get; set; }

        public CodeBlockNode(string name,ICNode parent)
        {
            Name = name;
            Value = null;
            Parent = parent;
            Childs = new List<ICNode>();
        }
        public CodeBlockNode(string name,ICNode parent,ICodeBlock val)
        {
            Name = name;
            Value = val;
            Parent = parent;
            Childs = new List<ICNode>();
        }
    }
    public class TokenNode : ICNode
    {
        public string Name { get; set; }
        /// <summary>
        /// Value is Token
        /// </summary>
        public object Value { get; set; }
        public ICNode Parent { get; set; }
        public List<ICNode> Childs { get; set; }

        public TokenNode(string name, ICNode parent)
        {
            Name = name;
            Value = null;
            Parent = parent;
            Childs = new List<ICNode>();
        }
        public TokenNode(string name, ICNode parent, Token val)
        {
            Name = name;
            Value = val;
            Parent = parent;
            Childs = new List<ICNode>();
        }
    }
}
