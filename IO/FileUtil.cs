using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VoltFramework.IO
{
    public static class FileUtil
    {
        public static void DeleteFolder(string folder)
        {
            if (Directory.Exists(folder))
            {
                foreach (string file in Directory.GetFiles(folder))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
                foreach (string ffolder in Directory.GetDirectories(folder))
                {
                    DeleteFolder(ffolder);
                }
                try
                {
                    Directory.Delete(folder);
                }
                catch { }
            }
        }
        public static void DeleteByExtInFolder(string folder,string[] ext)
        {
            if (Directory.Exists(folder))
            {
                foreach (string file in Directory.GetFiles(folder))
                {
                    foreach (string toDel in ext)
                    {
                        FileInfo info = new FileInfo(file);
                        if (info.Name.EndsWith(toDel))
                            File.Delete(file);
                    }
                }
            }
        }
        public static void DeleteFilesInFolder(string folder,string[] files)
        {
            if(Directory.Exists(folder))
            {
                foreach(string file in Directory.GetFiles(folder))
                {
                    foreach(string toDel in files)
                    {
                        FileInfo info = new FileInfo(file);
                        if (info.Name == toDel)
                            File.Delete(file);
                    }
                }
            }
        }
        public static Dictionary<string,string> GetFilesFromFolder(string folderPath)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            if(Directory.Exists(folderPath))
            {
                foreach(string file in Directory.GetFiles(folderPath))
                {
                    FileInfo info = new FileInfo(file);
                    res.Add(info.Name, ReadFile(file));
                }
                foreach(string folder in Directory.GetDirectories(folderPath))
                {
                    Dictionary<string, string> result = GetFilesFromFolder(folder);
                    foreach(string fileName in result.Keys)
                    {
                        string fileCode = "";result.TryGetValue(fileName,out fileCode);
                        res.Add(fileName, fileCode);
                    }
                }
            }
            return res;
        }
        public static string[] ReadFilesFromFolder(string folderPath)
        {
            List<string> files = new List<string>();
            if(Directory.Exists(folderPath))
            {
                foreach(string file in Directory.GetFiles(folderPath))
                {
                    files.Add(ReadFile(file));
                }
                foreach(string folder in Directory.GetDirectories(folderPath))
                {
                    files.AddRange(ReadFilesFromFolder(folder));
                }
            }
            return files.ToArray();
        }
        public static void RewriteFile(string path,string newText)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(newText);
            sw.Close();
        }
        public static string ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string res = sr.ReadToEnd();
            sr.Close();
            return res;
        }
    }
}
