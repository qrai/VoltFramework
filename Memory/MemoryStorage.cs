using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.Memory
{
    public enum Visibility
    {
        Public,Private,Protected
    }

    public class MemoryVariable<T>
    {
        public Visibility visible { get; set; }
        public T value { get; set; }
        public int address { get; }

        public MemoryVariable(T val,Visibility vis)
        {
            visible = vis;
            value = val;
            address = new Random(255255255).Next();
        }
    }

    public class MemoryStorage<T>
    {
        public string Name { get; }
        private Stack<MemoryVariable<T>> memoryStack;

        public MemoryStorage(string name)
        {
            Name = name;
            memoryStack = new Stack<MemoryVariable<T>>();
        }

        public void PushMemory(MemoryVariable<T> var)
        {
            memoryStack.Push(var);
        }
        public MemoryVariable<T> PopMemory()
        {
            return memoryStack.Pop();
        }

        public List<MemoryVariable<T>> GetMemory()
        {
            return memoryStack.ToList();
        }
    }
}
