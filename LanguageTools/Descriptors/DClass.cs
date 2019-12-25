using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools.Descriptors
{
    public class DClass : IDescriptor
    {
        public List<DVariable> Properties { get; set; }
        public List<DMethod> Methods { get; set; }
        public string Name { get; }
        public Visibility Visible { get; }
        public Modif Modif { get; }

        public DClass(string name,Visibility vis,Modif m)
        {
            Name = name;
            Visible = vis;
            Modif = m;
            Properties = new List<DVariable>();
            Methods = new List<DMethod>();
        }
        public DClass(string name,List<DVariable> vars,List<DMethod> funcs, Visibility vis,Modif m)
        {
            Name = name;
            Visible = vis;
            Modif = m;
            Properties = vars;
            Methods = funcs;
        }

        public void AddMethod(DMethod method)
        {
            Methods.Add(method);
        }
        public void AddVariable(DVariable var)
        {
            Properties.Add(var);
        }

        public bool NameExists(string name)
        {
            bool res = false;
            foreach(DMethod m in Methods)
            {
                if (m.Name == name)
                    res = true;
            }
            foreach (DVariable v in Properties)
            {
                if (v.Name == name)
                    res = true;
            }
            return res;
        }
    }
}
