using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VoltFramework.WinForms.Utils
{
    public static class TreeViewUtils
    {
        /// <summary>
        /// Populates tree from paths
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="paths"></param>
        /// <param name="pathSeparator"></param>
        public static void PopulateTreeView(this TreeView treeView, List<string> paths, char pathSeparator)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
            }
        }
        /// <summary>
        /// Populates tree from paths
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="paths"></param>
        /// <param name="pathSeparator"></param>
        public static void PopulateTree(this TreeNodeCollection treeView, List<string> paths, char pathSeparator,bool ide)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
            }
        }
        /// <summary>
        /// Populates treenode from paths
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="paths"></param>
        /// <param name="pathSeparator"></param>
        public static void PopulateTreeNode(this TreeNode tree,List<string> paths,char pathSeparator)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = tree.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = tree.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
            }
        }

        /// <summary>
        /// Adds node with tag
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="text"></param>
        /// <param name="tag"></param>
        public static void AddWithTag(this TreeNodeCollection tree,string text,object tag)
        {
            TreeNode t = new TreeNode();
            t.Text = text;
            t.Tag = tag;
            tree.Add(t);
        }
    }
}
