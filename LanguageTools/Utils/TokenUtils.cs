using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools.Utils
{
    public static class TokenUtils
    {
        public static bool Exist(this Token[] tok,int index)
        {
            try
            {
                if (tok[index] != null)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
    }
}
