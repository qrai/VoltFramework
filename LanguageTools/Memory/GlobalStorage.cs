using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoltFramework.LanguageTools.Descriptors;

namespace VoltFramework.LanguageTools.Memory
{
    public class GlobalStorage
    {
        public List<DClass> ClassStorage { get; private set; }
        public List<DMethod> MethodStorage { get; private set; }
        public List<DVariable> VariableStorage { get; private set; }
        
        public GlobalStorage()
        {
            ClassStorage = new List<DClass>();
            MethodStorage = new List<DMethod>();
            VariableStorage = new List<DVariable>();
        }

        /// <summary>
        /// Checks is that name exists as variable or method
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool NameExists(string name)
        {
            bool res = false;
            foreach (DClass _class in ClassStorage)
            {
                if (_class.Name == name)
                    res = true;
            }
            foreach (DMethod method in MethodStorage)
            {
                if (method.Name == name)
                    res = true;
            }
            foreach(DVariable var in VariableStorage)
            {
                if (var.Name == name)
                    res = true;
            }
            return res;
        }
        public bool ClassExists(string name)
        {
            bool res = false;
            foreach (DClass _class in ClassStorage)
            {
                if (_class.Name == name)
                    res = true;
            }
            return res;
        }
        public bool MethodExists(string name)
        {
            bool res = false;
            foreach (DMethod method in MethodStorage)
            {
                if (method.Name == name)
                    res = true;
            }
            return res;
        }
        public bool VarExists(string name)
        {
            bool res = false;

            foreach (DVariable var in VariableStorage)
            {
                if (var.Name == name)
                    res = true;
            }
            return res;
        }

        public IDescriptor FindByName(string name)
        {
            IDescriptor res = null;
            foreach (DClass _class in ClassStorage)
            {
                if (_class.Name == name)
                    res = _class;
            }
            foreach (DMethod method in MethodStorage)
            {
                if (method.Name == name)
                    res = method;
            }
            foreach (DVariable var in VariableStorage)
            {
                if (var.Name == name)
                    res = var;
            }
            return res;
        }

        #region Storage add,get,remove,clear,etc
        public void AddClass(DClass cls)
        {
            ClassStorage.Add(cls);
        }
        public void AddMethod(DMethod method)
        {
            if (method.Modif == Modif.Static)
                MethodStorage.Add(method);
            else
                LangException.Throw("Method was not static");
        }
        public void AddVariable(DVariable var)
        {
            if(var.Modif == Modif.Static)
                VariableStorage.Add(var);
            else
                LangException.Throw("Variable was not static");
        }

        public DClass GetClass(string name)
        {
            DClass res = null;
            foreach(DClass cl in ClassStorage)
            {
                if (cl.Name == name)
                    res = cl;
            }
            return res;
        }
        public DMethod GetMethod(string name)
        {
            DMethod res = null;
            foreach (DMethod method in MethodStorage)
            {
                if (method.Name == name)
                    res = method;
            }
            return res;
        }
        public DVariable GetVariable(string name)
        {
            DVariable res = null;
            foreach (DVariable var in VariableStorage)
            {
                if (var.Name == name)
                    res = var;
            }
            return res;
        }
        #endregion
    }
}
