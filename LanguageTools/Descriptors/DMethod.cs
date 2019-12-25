using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoltFramework.LanguageTools.Utils;
namespace VoltFramework.LanguageTools.Descriptors
{
    public enum MethodReturn
    {
        None,Var,Int,String
    }
    public class DMethod : IDescriptor
    {
        public string Name { get; }
        public MethodReturn RetType { get; }
        public Modif Modif { get; }
        public Visibility Visible { get; }
        public object[] Arguments { get; set; }
        /// <summary>
        /// Token[] is args
        /// </summary>
        public Token[] Code { get; }
        public DescribedAction NamesAction { get; set; }
        public DMethod(string name, Token[] code, Visibility vis, MethodReturn type,Modif m,
            DescribedAction act)
        { Name = name; Code=code; Visible = vis; RetType = type; Modif = m; NamesAction = act; }

        public void Execute()
        {
            ActionsList acts = new ActionsList();
            acts.AddAction(NamesAction);
            Code.Interprete(acts);
        }
    }
}
