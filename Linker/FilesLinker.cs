using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VoltFramework.Crypto;
using VoltFramework.IO;
namespace VoltFramework.Linker
{
    //used only here and in FileUnlinker
    public class FileDesc
    {
        public string content { get; set; }
        public string path { get; set; }
        public FileDesc(string c, string p)
        { content = c; path = p; }
        public string GetName()
        {
            FileInfo info = new FileInfo(path);
            return info.Name;
        }
    }

    public class CodeLinker
    {
        private Dictionary<string, string> codes;

        public CodeLinker(Dictionary<string, string> Codes)
        {
            codes = Codes;
        }

        private string GetCode(string name)
        {
            string res = "";
            codes.TryGetValue(name, out res);
            return res;
        }

        public string Link(bool encrypt, string data, string data2)
        {
            int i = 0;
            string finalContent = "";
            foreach (string file in codes.Keys)
            {
                finalContent += data2 + "_FILE-NAME:" + file + ":\n";
                finalContent += GetCode(file) + "\n";
                i++;
            }

            if (encrypt)
                return CryptoAction.Encrypt(finalContent, data);
            else
                return finalContent;
        }
    }
    public class FilesLinker
    {
        private string[] paths;

        public FilesLinker(string[] fPaths)
        {
            paths = fPaths;
        }

        private bool PathsExists()
        {
            bool res = false;
            if (paths.Length > 0)
            {
                bool[] reses = new bool[paths.Length];
                int i = 0;
                foreach (string path in paths)
                {
                    reses[i] = File.Exists(path);
                    i++;
                }
                bool nres = true;
                foreach (bool ress in reses)
                {
                    if (ress == false)
                        nres = false;
                }
                if (nres == true)
                    res = true;
            }
            return res;
        }

        public void Link(string outPath, bool encrypt, string data, string data2)
        {
            if (PathsExists())
            {
                //read files content
                FileDesc[] contents = new FileDesc[paths.Length]; int i = 0;
                foreach (string path in paths)
                {
                    StreamReader sr = new StreamReader(path);
                    contents[i] = new FileDesc(sr.ReadToEnd(), path);
                    sr.Close();
                    i++;
                }
                int i2 = 0;
                string finalContent = "";
                foreach (FileDesc file in contents)
                {
                    finalContent += data2 + "_FILE-NAME:" + file.GetName() + ":\n";
                    finalContent += file.content + "\n";
                    i2++;
                }
                StreamWriter sw = new StreamWriter(outPath);
                sw.Write(finalContent);
                sw.Close();
                if (encrypt)
                    FileUtil.RewriteFile(outPath, CryptoAction.Encrypt(FileUtil.ReadFile(outPath), data));
            }
            else
                throw new Exception("Some of paths not exists");
        }
    }
}
