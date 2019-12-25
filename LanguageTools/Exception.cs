using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public static class LangException
    {
        public static Action<string> Catch;
         public static void Throw(string text)
        {
            if (Catch != null)
                Catch(text);
            else
                Console.WriteLine("LANG-ERROR:" + text);
        }
    }
}
