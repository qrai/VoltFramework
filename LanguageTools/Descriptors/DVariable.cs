using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools.Descriptors
{
    public class DVariable : IDescriptor
    {
        public string Name { get; }
        public object Value { get; set; }
        public int Address { get; }
        public Visibility Visible { get; }
        public Modif Modif { get; }

        public DVariable(string name,object val,Visibility vis,Modif m)
        { Name = name; Value = val;Visible = vis;Address = new Random(255255255).Next(); Modif = m; }
    }
}
