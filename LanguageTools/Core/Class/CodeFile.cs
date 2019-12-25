using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools
{
    public class CodeFile
    {
        public string Code { get; set; }
        public CodeFile(string code)
        {
            Code = code;
        }
    }
}
