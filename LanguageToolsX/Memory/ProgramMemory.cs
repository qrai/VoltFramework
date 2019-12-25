using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageToolsX.Memory
{
    public class ProgramMemory
    {
        public List<MemoryObject> MemoryStack { get; private set; }

        public ProgramMemory()
        {
            MemoryStack = new List<MemoryObject>();
        }

        public ProgramMemory(int size)
        {
            MemoryStack = new List<MemoryObject>(size);
        }

        #region MEMORY_STACK
        public void AddObject(MemoryObject obj)
        {
            if (AnyObjectExist(obj.Address) == false)
            {
                MemoryStack.Add(obj);
            }
            else
                Logger.ErrorCatch(new MemoryError("Object with this address is already exists(addr:" + obj.Address.ToString() + ")"));
        }

        public void DeleteObject(int adr)
        {
            if (FindAnyObject(adr) != null)
            {
                MemoryStack.Remove(FindAnyObject(adr));
            }
            else
                Logger.ErrorCatch(new MemoryError("Failed deleting memory object(addr:" + adr.ToString() + ")"));
        }
        public void DeleteAll()
        {
            MemoryStack.Clear();
        }

        public MemoryObject[] FindPublicObject(string name)
        {
            List<MemoryObject> result = null;
            foreach(MemoryObject obj in MemoryStack)
            {
                if (obj.Name == name && obj.Visibility == MemoryVisibility.Public)
                    result.Add(obj);
            }
            return result.ToArray();
        }
        public MemoryObject[] FindAnyObject(string name)
        {
            List<MemoryObject> result = null;
            foreach (MemoryObject obj in MemoryStack)
            {
                if (obj.Name == name)
                    result.Add(obj);
            }
            return result.ToArray();
        }
        public MemoryObject[] FindHiddenObject(string name)
        {
            List<MemoryObject> result = null;
            foreach (MemoryObject obj in MemoryStack)
            {
                if (obj.Name == name && obj.Visibility == MemoryVisibility.Hidden)
                    result.Add(obj);
            }
            return result.ToArray();
        }

        public MemoryObject FindPublicObject(int adr)
        {
            MemoryObject result = null;
            foreach (MemoryObject obj in MemoryStack)
            {
                if (obj.Address == adr && obj.Visibility == MemoryVisibility.Public)
                    result = obj;
            }
            return result;
        }
        public MemoryObject FindAnyObject(int adr)
        {
            MemoryObject result = null;
            foreach (MemoryObject obj in MemoryStack)
            {
                if (obj.Address == adr)
                    result = obj;
            }
            return result;
        }
        public MemoryObject FindHiddenObject(int adr)
        {
            MemoryObject result = null;
            foreach (MemoryObject obj in MemoryStack)
            {
                if (obj.Address == adr && obj.Visibility == MemoryVisibility.Hidden)
                    result = obj;
            }
            return result;
        }

        public bool PublicObjectExist(string name)
        {
            if (FindPublicObject(name).Length > 0)
                return true;
            else
                return false;
        }
        public bool AnyObjectExist(string name)
        {
            if (FindAnyObject(name).Length > 0)
                return true;
            else
                return false;
        }
        public bool HiddenObjectExist(string name)
        {
            if (FindHiddenObject(name).Length > 0)
                return true;
            else
                return false;
        }

        public bool PublicObjectExist(int adr)
        {
            if (FindPublicObject(adr) != null)
                return true;
            else
                return false;
        }
        public bool AnyObjectExist(int adr)
        {
            if (FindAnyObject(adr) != null)
                return true;
            else
                return false;
        }
        public bool HiddenObjectExist(int adr)
        {
            if (FindHiddenObject(adr) != null)
                return true;
            else
                return false;
        }
        #endregion
    }
}
