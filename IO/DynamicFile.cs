using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VoltFramework.IO
{
    public class DynamicFile
    {
        private string Path;
        
        public string Content
        {
            get
            {
                StreamReader sr = new StreamReader(Path);
                string res = sr.ReadToEnd();
                sr.Close();
                return res;
            }
            set
            {
                StreamWriter sw = new StreamWriter(Path);
                sw.Write(value);
                sw.Close();
            }
        }

        public DynamicFile(string path)
        {
            Path = path;
        }
    }
}
