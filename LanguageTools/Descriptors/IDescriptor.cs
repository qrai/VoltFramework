using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools.Descriptors
{
    public enum Visibility
    { Public, Hidden }
    public enum Modif
    { Static,NonStatic }
    public interface IDescriptor
    {
        string Name { get; }
        Visibility Visible { get; }
        Modif Modif { get; }
    }

    public static class VisibleUtils
    {
        public static bool IsPublic(this IDescriptor vis)
        {
            if (vis.Visible == Visibility.Public)
                return true;
            else
                return false;
        }
        public static bool IsHidden(this IDescriptor vis)
        {
            if (vis.Visible == Visibility.Hidden)
                return true;
            else
                return false;
        }
    }
    public static class NameUtils
    {
        public static IDescriptor[] FindDescriptor(this List<IDescriptor> list,string name)
        {
            List<IDescriptor> found = new List<IDescriptor>();
            foreach(IDescriptor named in list)
            {
                if (named.Name == name)
                    found.Add(named);
            }
            return found.ToArray();
        }
        public static DMethod[] FindDescriptor(this List<DMethod> list, string name)
        {
            List<DMethod> found = new List<DMethod>();
            foreach (DMethod named in list)
            {
                if (named.Name == name)
                    found.Add(named);
            }
            return found.ToArray();
        }
        public static DVariable[] FindDescriptor(this List<DVariable> list, string name)
        {
            List<DVariable> found = new List<DVariable>();
            foreach (DVariable named in list)
            {
                if (named.Name == name)
                    found.Add(named);
            }
            return found.ToArray();
        }
    }
}
