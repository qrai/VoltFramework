using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageToolsX.Memory
{
    public enum MemoryVisibility
    {
        Public,Hidden,NotExists
    }

    public class MemoryObject
    {
        public MemoryVisibility Visibility { get; private set; }
        public string Name { get; private set; }
        public int Address { get; private set; }
        public object Value { get; set; }

        public MemoryObject(MemoryVisibility vis, string name,object value)
        {
            Visibility = vis;
            Name = name;
            Address = new Random().Next(0, 90000000);
            Value = value;
        }

        public void Destroy()
        {
            Address = -1;
            Value = null;
            Name = "-";
            Visibility = MemoryVisibility.NotExists;
        }
    }
}
