using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VoltFramework.IO
{
    public class FolderManager
    {
        private string Path;

        public FolderManager(string path)
        {
            Path = path;
        }

        public void Create()
        {
            try
            {
                Directory.CreateDirectory(Path);
            }
            catch (Exception e)
            {
                throw new Exception("Failed creating folder("+e.ToString()+")");
            }
        }
        public void Delete()
        {
            try
            {
                Directory.Delete(Path);
            }
            catch (Exception e)
            {
                throw new Exception("Failed deleting folder(" + e.ToString() + ")");
            }
        }
        public void Rename(string newName)
        {
            try
            {
                DirectoryInfo i = new DirectoryInfo(Path);
                string oldName = i.Name;
                Directory.Move(i.FullName, i.FullName.Replace(@"\" + oldName, @"\" + newName));
            }
            catch (Exception e)
            {
                throw new Exception("Failed renaming folder(" + e.ToString() + ")");
            }
        }
        public bool IsExists()
        {
            if (Directory.Exists(Path))
                return true;
            else
                return false;
        }
    }
}
