using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VoltFramework.Exceptions
{
    public static class Exc
    {
        public static void WrongFormat()
        {
            throw new Exception("Workspace was had wrong format");
        }
        public static void RootDirNotExist(string dir)
        {
            throw new Exception("Root folder was not exist(" + dir + ")");
        }
        public static void SolutionExists(string name)
        {
            throw new Exception("Solution is already exist(" + name + ")");
        }
        public static void ProjectExists(string name)
        {
            throw new Exception("Project is already exist(" + name + ")");
        }
        public static void FolderExists(string name)
        {
            throw new Exception("Folder is already exist(" + name + ")");
        }
        public static void FileExists(string name)
        {
            throw new Exception("File is already exist(" + name + ")");
        }

        public static void Custom(Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        public static void Custom(string ex)
        {
            throw new Exception(ex);
        }
        public static void Message(string ex)
        {
            MessageBox.Show(ex, "Error");
        }
    }
}
