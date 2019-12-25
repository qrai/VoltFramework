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
    public class CodeUnlinker
    {
        private string das;
        public CodeUnlinker(string data)
        {
            das = data;
        }
        public Dictionary<string, string> Unlink(bool dec, bool log, string data, string data2)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            string currentFileName = null;
            string currentFileContent = "";
            //if (decrypt)
            //    FileUtil.RewriteFile(path, CryptoAction.Decrypt(FileUtil.ReadFile(path),"vxl"));
            string text;
            if (dec)
                text = CryptoAction.Decrypt(das, data);
            else
                text = das;
            string[] lines = text.Split(new string[] { "\n" }, StringSplitOptions.None);

            if (log)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("PARSING PROCESS...");
            }
            foreach (string line in lines)
            {
                if (log)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("PARSING:" + line);
                }
                if (currentFileName == null)
                {
                    if (line.Contains(data2 + "_FILE-NAME"))
                    {
                        currentFileName = line.Replace(data2 + "_FILE-NAME", "");
                        currentFileName = currentFileName.Replace(":", "");
                        if (log)
                            Console.WriteLine("NEW CURRENT-FILE:" + currentFileName);
                    }
                    else
                    {
                        if (log)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("PARSING-ERROR: FILE-NAME line expected(" + line + ")");
                        }
                    }
                }
                else if (line.Contains(data2 + "_FILE-NAME"))
                {
                    res.Add(currentFileName, currentFileContent);
                    currentFileContent = "";
                    currentFileName = line.Replace(data2 + "_FILE-NAME", "");
                    currentFileName = currentFileName.Replace(":", "");
                    if (log)
                        Console.WriteLine("NEW CURRENT-FILE:" + currentFileName);
                }
                else if (!line.Contains(data2 + "_FILE-NAME"))
                    currentFileContent += line + "\n";
            }
            res.Add(currentFileName, currentFileContent);
            Console.ForegroundColor = ConsoleColor.White;
            return res;
        }
    }
    public class FileUnlinker
    {
        private string path;
        public FileUnlinker(string fPath)
        {
            path = fPath;
        }
        private bool FileExist()
        {
            return File.Exists(path);
        }
        /// <summary>
        /// Returns array of file contents
        /// </summary>
        /// <returns></returns>
        public FileDesc[] Unlink(bool decrypt,bool log,string data)
        {
            if (FileExist())
            {
                List<FileDesc> descs = new List<FileDesc>();
                string currentFileName = null;
                string currentFileContent = "";
                //if (decrypt)
                //    FileUtil.RewriteFile(path, CryptoAction.Decrypt(FileUtil.ReadFile(path),"vxl"));
                string text;
                if (decrypt)
                    text = CryptoAction.Decrypt(FileUtil.ReadFile(path), data);
                else
                    text = FileUtil.ReadFile(path);
                string[] lines = text.Split(new string[] { "\n" }, StringSplitOptions.None);

                if (log)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("PARSING PROCESS...");
                }
                foreach (string line in lines)
                {
                    if (log)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("PARSING:" + line);
                    }
                    if (currentFileName == null)
                    {
                        if (line.Contains("FILE-NAME"))
                        {
                            currentFileName = line.Replace("FILE-NAME", "");
                            currentFileName = currentFileName.Replace(":", "");
                            if(log)
                                Console.WriteLine("NEW CURRENT-FILE:" + currentFileName);
                        }
                        else
                        {
                            if (log)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("PARSING-ERROR: FILE-NAME line expected(" + line + ")");
                            }
                        }
                    }
                    else if (line.Contains("FILE-NAME"))
                    {
                        descs.Add(new FileDesc(currentFileContent, currentFileName));
                        currentFileContent = "";
                        currentFileName = line.Replace("FILE-NAME", "");
                        currentFileName = currentFileName.Replace(":", "");
                        if(log)
                            Console.WriteLine("NEW CURRENT-FILE:" + currentFileName);
                    }
                    else if(!line.Contains("FILE-NAME"))
                        currentFileContent += line + "\n";
                }
                descs.Add(new FileDesc(currentFileContent, currentFileName));
                Console.ForegroundColor = ConsoleColor.White;
                return descs.ToArray();
            }
            else
                throw new Exception("File not found");
        }
    }
}
